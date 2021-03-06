﻿//=======================================================================
// Copyright Martin "quill18" Glaude 2015-2016.
//		http://quill18.com
//=======================================================================

using UnityEngine;
using System.Collections.Generic;
using System;

public class Job {

	// This class holds info for a queued up job, which can include
	// things like placing furniture, moving stored inventory,
	// working at a desk, and maybe even fighting enemies.

	public Tile tile;
	public float jobTime {
		get;
		protected set;
	}

	protected float jobTimeRequired;

	protected bool jobRepeats = false;

	public string objectName {
		get; protected set;
	}

	public Furniture furniturePrototype;

	public Furniture furniture; // The piece of furniture that owns this job. Frequently will be null.

	public bool acceptsAnyInventoryItem = false;

	Action<Job> cbJobCompleted; // We have finished the work cycle and so things should probably get built or whatever. 
	Action<Job> cbJobStopped;   // The job has been stopped, either because it's non-repeating or was cancelled.
	Action<Job> cbJobWorked;    // Gets called each time some work is performed -- maybe update the UI?

	public bool canTakeFromStockpile = true;

	public Dictionary<string, Inventory> inventoryRequirements;

	public Job(Tile tile, string jobObjectName, Action<Job> cbJobComplete, float jobTime, Inventory[] inventoryRequirements, bool jobRepeats = false) {
		this.tile = tile;
		this.objectName = jobObjectName;
		this.cbJobCompleted += cbJobComplete;
		this.jobTimeRequired = this.jobTime = jobTime;
		this.jobRepeats = jobRepeats;

		this.inventoryRequirements = new Dictionary<string, Inventory>();
		if (inventoryRequirements != null) {
		//	foreach (Inventory inv in inventoryRequirements) {
		//		this.inventoryRequirements[inv.objectName] = inv.Clone();
		//	}
		}
	}

	protected Job(Job other) {
		this.tile = other.tile;
		this.objectName = other.objectName;
		this.cbJobCompleted = other.cbJobCompleted;
		this.jobTime = other.jobTime;

		this.inventoryRequirements = new Dictionary<string, Inventory>();
		if (inventoryRequirements != null) {
			foreach (Inventory inv in other.inventoryRequirements.Values) {
				this.inventoryRequirements[inv.objectName] = inv.Clone();
			}
		}
	}

	virtual public Job Clone() {
		return new Job(this);
	}

	public void RegisterJobCompletedCallback(Action<Job> cb) {
		cbJobCompleted += cb;
	}

	public void RegisterJobStoppedCallback(Action<Job> cb) {
		cbJobStopped += cb;
	}

	public void UnregisterJobCompletedCallback(Action<Job> cb) {
		cbJobCompleted -= cb;
	}

	public void UnregisterJobStoppedCallback(Action<Job> cb) {
		cbJobStopped -= cb;
	}

	public void RegisterJobWorkedCallback(Action<Job> cb) {
		cbJobWorked += cb;
	}

	public void UnregisterJobWorkedCallback(Action<Job> cb) {
		cbJobWorked -= cb;
	}

	public void DoWork(float workTime) {
		// Check to make sure we actually have everything we need. 
		// If not, don't register the work time.
		if (HasAllMaterial() == false) {
			//Debug.LogError("Tried to do work on a job that doesn't have all the material.");

			// Job can't actually be worked, but still call the callbacks
			// so that animations and whatnot can be updated.
			if (cbJobWorked != null)
				cbJobWorked(this);

			return;
		}

		jobTime -= workTime;

		if (cbJobWorked != null)
			cbJobWorked(this);

		if (jobTime <= 0) {
			// Do whatever is supposed to happen with a job cycle completes.
			if (cbJobCompleted != null)
				cbJobCompleted(this);

			if (jobRepeats == false) {
				// Let everyone know that the job is officially concluded
				if (cbJobStopped != null)
					cbJobStopped(this);
			} else {
				// This is a repeating job and must be reset.
				jobTime += jobTimeRequired;
			}
		}
	}

	public void CancelJob() {
		if (cbJobStopped != null)
			cbJobStopped(this);

		World.current.jobQueue.Remove(this);
	}

	public bool HasAllMaterial() {
		foreach (Inventory inv in inventoryRequirements.Values) {
			if (inv.maxStackSize > inv.stackSize)
				return false;
		}

		return true;
	}

	public int DesiresInventoryType(Inventory inv) {
		if (acceptsAnyInventoryItem) {
			return inv.maxStackSize;
		}

		if (inventoryRequirements.ContainsKey(inv.objectName) == false) {
			return 0;
		}

		if (inventoryRequirements[inv.objectName].stackSize >= inventoryRequirements[inv.objectName].maxStackSize) {
			// We already have all that we need!
			return 0;
		}

		// The inventory is of a type we want, and we still need more.
		return inventoryRequirements[inv.objectName].maxStackSize - inventoryRequirements[inv.objectName].stackSize;
	}

	public Inventory GetFirstDesiredInventory() {
		foreach (Inventory inv in inventoryRequirements.Values) {
			if (inv.maxStackSize > inv.stackSize)
				return inv;
		}

		return null;
	}

}
