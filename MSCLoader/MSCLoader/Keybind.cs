﻿using System.Collections.Generic;
using UnityEngine;

namespace MSCLoader
{
	/// <summary>
	/// Add easily rebindable keybinds.
	/// </summary>
	public class Keybind
	{
        /// <summary>
        /// List of Keybinds
        /// </summary>
        public static List<Keybind> Keybinds = new List<Keybind>();
        /// <summary>
        /// List of Default Keybinds
        /// </summary>
        public static List<Keybind> DefaultKeybinds = new List<Keybind>();

		/// <summary>
		/// The ID of the keybind (Should only be used once in your mod).
		/// </summary>
		public string ID { get; set; }

		/// <summary>
		/// The name that will be displayed in settings
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The KeyCode the user will have to press.
		/// </summary>
		public KeyCode Key { get; set; }

		/// <summary>
		/// The modifier KeyCode the user will have to press with the Key.
		/// </summary>
		public KeyCode Modifier { get; set; }

		/// <summary>
		/// The Mod this Keybind belongs to (This is set when using Keybind.Add).
		/// </summary>
		public Mod Mod { get; set; }


        /// <summary>
        /// Add a keybind.
        /// </summary>
        /// <param name="mod">The instance of your mod.</param>
        /// <param name="key">The Keybind to add.</param>
        /// <example><code source="Examples.cs" region="KeyBindAdd" lang="C#" 
        /// title="Keybind Add" /></example>
        public static void Add(Mod mod, Keybind key)
		{
			key.Mod = mod;
			Keybinds.Add(key);
			DefaultKeybinds.Add(new Keybind(key.ID, key.Name, key.Key, key.Modifier) { Mod = mod });
		}

        /// <summary>
        /// Return all keybinds for mod.
        /// </summary>
        /// <param name="mod">The mod to get the Keybinds for.</param>
        /// <returns>List of Keybinds for the mod.</returns>
        public static List<Keybind> Get(Mod mod) => Keybinds.FindAll(x => x.Mod == mod);

        /// <summary>
        /// Return all default keybinds for mod.
        /// </summary>
        /// <param name="mod">The mod to get the keybinds for.</param>
        /// <returns>List of default Keybinds for the mod.</returns>
        public static List<Keybind> GetDefault(Mod mod) => DefaultKeybinds.FindAll(x => x.Mod == mod);

        /// <summary>
        /// Constructor for Keybind without modifier
        /// </summary>
        /// <param name="id">The ID of the Keybind.</param>
        /// <param name="name">The name of the Keybind.</param>
        /// <param name="key">The KeyCode the user will press.</param>
        /// <example><code source="Examples.cs" region="KeyBind1" lang="C#" 
        /// title="Keybind without modifier" /></example>
        public Keybind(string id, string name, KeyCode key)
		{
			ID = id;
			Name = name;
			Key = key;
			Modifier = KeyCode.None;
		}

        /// <summary>
        /// Constructor for Keybind
        /// </summary>
        /// <param name="id">The ID of the Keybind (Used only once in your mod).</param>
        /// <param name="name">The name of the Keybind that will be displayed.</param>
        /// <param name="key">The KeyCode the user will press.</param>
        /// <param name="modifier">The modifier KeyCode the user will have to press.</param>
        /// <example><code source="Examples.cs" region="KeyBind2" lang="C#" 
        /// title="Keybind and modifier" /></example>
        public Keybind(string id, string name, KeyCode key, KeyCode modifier)
		{
			ID = id;
			Name = name;
			Key = key;
			Modifier = modifier;
		}

        /// <summary>
        /// Checks if the Keybind is being held down.
        /// </summary>
        /// <returns>If the Keybind is being held down.</returns>
        /// <example><code source="Examples.cs" region="KeyBindPress" lang="C#" 
        /// title="Keybind and modifier" /></example>
        public bool IsPressed()
		{
			if (Modifier != KeyCode.None)
			{
				return Input.GetKey(Modifier) && Input.GetKey(Key);
			}

			return Input.GetKey(Key);
		}

        /// <summary>
        /// Checks if the Keybind was just pressed.
        /// </summary>
        /// <returns>If the Keybind is being pressed.</returns>
        /// <example><code source="Examples.cs" region="KeyBindDown" lang="C#" 
        /// title="Keybind and modifier" /></example>
        public bool IsDown()
		{
			if (Modifier != KeyCode.None)
			{
				return Input.GetKey(Modifier) && Input.GetKeyDown(Key);
			}

			return Input.GetKeyDown(Key);
		}
	}
}
