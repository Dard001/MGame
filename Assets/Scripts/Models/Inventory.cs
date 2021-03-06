﻿//=======================================================================
// Copyright Martin "quill18" Glaude 2015-2016.
//		http://quill18.com
//=======================================================================

using UnityEngine;
using System.Collections;
using System;

// Inventory are things that are lying on the floor/stockpile, like a bunch of metal bars
// or potentially a non-installed copy of furniture (e.g. a cabinet still in the box from Ikea)


public class Inventory {
	public string objectName = "Steel Plate";
	public int maxStackSize = 50;

	protected int _stackSize = 1;
	public int stackSize {
		get { return _stackSize; }
		set {
			if (_stackSize != value) {
				_stackSize = value;
				if (cbInventoryChanged != null) {
					cbInventoryChanged(this);
				}
			}
		}
	}

	// The function we callback any time our tile's data changes
	Action<Inventory> cbInventoryChanged;

	public Tile tile;
	public Character character;

	public Inventory() {

	}

	public Inventory(string objectName, int maxStackSize, int stackSize) {
		this.objectName = objectName;
		this.maxStackSize = maxStackSize;
		this.stackSize = stackSize;
	}

	protected Inventory(Inventory other) {
		objectName = other.objectName;
		maxStackSize = other.maxStackSize;
		stackSize = other.stackSize;
	}

	public virtual Inventory Clone() {
		return new Inventory(this);
	}

	public void RegisterChangedCallback(Action<Inventory> callback) {
		cbInventoryChanged += callback;
	}

	public void UnregisterChangedCallback(Action<Inventory> callback) {
		cbInventoryChanged -= callback;
	}


}
