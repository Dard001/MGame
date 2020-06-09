//=======================================================================
// Copyright Martin "quill18" Glaude 2015-2016.
//		http://quill18.com
//=======================================================================

using UnityEngine;
using System.Collections.Generic;

public class InventoryManager {

	// This is a list of all "live" inventories.
	// Later on this will likely be organized by rooms instead
	// of a single master list. (Or in addition to.)
	public Dictionary<string, List<Inventory>> inventories;

	public InventoryManager() {
		inventories = new Dictionary<string, List<Inventory>>();
	}

	void CleanupInventory(Inventory inv) {
		if (inv.stackSize == 0) {
			if (inventories.ContainsKey(inv.objectName)) {
				inventories[inv.objectName].Remove(inv);
			}
			if (inv.tile != null) {
				inv.tile.inventory = null;
				inv.tile = null;
			}
			if (inv.character != null) {
				inv.character.inventory = null;
				inv.character = null;
			}
		}

	}

	public bool PlaceInventory(Tile tile, Inventory inv) {

		bool tileWasEmpty = tile.inventory == null;

		if (tile.PlaceInventory(inv) == false) {
			// The tile did not accept the inventory for whatever reason, therefore stop.
			return false;
		}

		CleanupInventory(inv);

		// We may also created a new stack on the tile, if the tile was previously empty.
		if (tileWasEmpty) {
			if (inventories.ContainsKey(tile.inventory.objectName) == false) {
				inventories[tile.inventory.objectName] = new List<Inventory>();
			}

			inventories[tile.inventory.objectName].Add(tile.inventory);

			World.current.OnInventoryCreated(tile.inventory);
		}

		return true;
	}

	public bool PlaceInventory(Job job, Inventory inv) {
		if (job.inventoryRequirements.ContainsKey(inv.objectName) == false) {
			Debug.LogError("Trying to add inventory to a job that it doesn't want.");
			return false;
		}

		job.inventoryRequirements[inv.objectName].stackSize += inv.stackSize;

		if (job.inventoryRequirements[inv.objectName].maxStackSize < job.inventoryRequirements[inv.objectName].stackSize) {
			inv.stackSize = job.inventoryRequirements[inv.objectName].stackSize - job.inventoryRequirements[inv.objectName].maxStackSize;
			job.inventoryRequirements[inv.objectName].stackSize = job.inventoryRequirements[inv.objectName].maxStackSize;
		} else {
			inv.stackSize = 0;
		}

		CleanupInventory(inv);

		return true;
	}

	public bool PlaceInventory(Character character, Inventory sourceInventory, int amount = -1) {
		if (amount < 0) {
			amount = sourceInventory.stackSize;
		} else {
			amount = Mathf.Min(amount, sourceInventory.stackSize);
		}

		if (character.inventory == null) {
			character.inventory = sourceInventory.Clone();
			character.inventory.stackSize = 0;
			inventories[character.inventory.objectName].Add(character.inventory);
		} else if (character.inventory.objectName != sourceInventory.objectName) {
			Debug.LogError("Character is trying to pick up a mismatched inventory object type.");
			return false;
		}

		character.inventory.stackSize += amount;

		if (character.inventory.maxStackSize < character.inventory.stackSize) {
			sourceInventory.stackSize = character.inventory.stackSize - character.inventory.maxStackSize;
			character.inventory.stackSize = character.inventory.maxStackSize;
		} else {
			sourceInventory.stackSize -= amount;
		}

		CleanupInventory(sourceInventory);

		return true;
	}


	public Inventory GetClosestInventoryOfType(string objectName, Tile t, int desiredAmount, bool canTakeFromStockpile) {
		// FIXME:
		//   a) We are LYING about returning the closest item.
		//   b) There's no way to return the closest item in an optimal manner
		//      until our "inventories" database is more sophisticated.
		//		(i.e. seperate tile inventory from character inventory and maybe
		//		 has room content optimization.)

		if (inventories.ContainsKey(objectName) == false) {
			Debug.LogError("GetClosestInventoryOfType -- no items of desired type.");
			return null;
		}

		foreach (Inventory inv in inventories[objectName]) {
			if (inv.tile != null &&
				(canTakeFromStockpile || inv.tile.furniture == null || inv.tile.furniture.IsStockpile() == false)
			) {
				return inv;
			}
		}

		return null;
	}
}
