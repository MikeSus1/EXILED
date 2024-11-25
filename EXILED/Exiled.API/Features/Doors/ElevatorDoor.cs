// -----------------------------------------------------------------------
// <copyright file="ElevatorDoor.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.API.Features.Doors
{
    using System.Collections.Generic;
    using System.Linq;

    using Exiled.API.Enums;
    using Interactables.Interobjects;
    using Interactables.Interobjects.DoorUtils;

    /// <summary>
    /// Represents an elevator door.
    /// </summary>
    public class ElevatorDoor : BasicDoor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElevatorDoor"/> class.
        /// </summary>
        /// <param name="door">The base <see cref="Interactables.Interobjects.ElevatorDoor"/> for this door.</param>
        /// <param name="room">The <see cref="Room"/> for this door.</param>
        internal ElevatorDoor(Interactables.Interobjects.ElevatorDoor door, List<Room> room)
            : base(door, room)
        {
            Base = door;
            Lift = Lift.Get(x => x.Group == Group).FirstOrDefault();
        }

        /// <summary>
        /// Gets the base <see cref="Interactables.Interobjects.ElevatorDoor"/>.
        /// </summary>
        public new Interactables.Interobjects.ElevatorDoor Base { get; }

        /// <summary>
        /// Gets the <see cref="ElevatorGroup"/> that this door's <see cref="Lift"/> belongs to.
        /// </summary>
        public ElevatorGroup Group => Base.Group;

        /// <summary>
        /// Gets the type according to <see cref="Group"/>.
        /// </summary>
        public ElevatorType ElevatorType => Group switch
        {
            ElevatorGroup.Scp049 => ElevatorType.Scp049,
            ElevatorGroup.GateA => ElevatorType.GateA,
            ElevatorGroup.GateB => ElevatorType.GateB,
            ElevatorGroup.LczA01 or ElevatorGroup.LczA02 => ElevatorType.LczA,
            ElevatorGroup.LczB01 or ElevatorGroup.LczB02 => ElevatorType.LczB,
            ElevatorGroup.Nuke => ElevatorType.Nuke,
            _ => ElevatorType.Unknown,
        };

        /// <summary>
        /// Gets the target panel settings for this lift.
        /// </summary>
        public PanelVisualSettings PanelSettings => Base.PanelSettings;

        /// <summary>
        /// Gets a value indicating whether gets the panel is permanent.
        /// </summary>
        public bool PermanentPanels => Base.PermanentPanels;

        /// <summary>
        /// Gets the <see cref="Lift"/> associated with this elevator door.
        /// </summary>
        public Lift Lift { get; }

        /// <summary>
        /// Returns the Door in a human-readable format.
        /// </summary>
        /// <returns>A string containing Door-related data.</returns>
        public override string ToString() => $"{base.ToString()} !{ElevatorType}!";
    }
}