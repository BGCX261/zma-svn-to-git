using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftWrapper.AddonInterface;
using MinecraftWrapper.Protocoll;
using Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel;
using Vitt.Andre.Tunnel;
using MinecraftWrapper.Player;

namespace Zicore.MinecraftAdmin.Commands
{
    /// <summary>
    /// make sure it inherits the Command class
    /// </summary>
    public class CommandTeleport : Command
    {
        /// <summary>
        /// the string for the base class is the name of this command
        /// it gets executed with !color then, should be the same like the in the register method
        /// </summary>
        /// <param name="mc">The minecraft handler</param>
        public CommandTeleport(IMinecraftHandler mc)
            :base(mc,"teleport")
        {
            
        }

        /// <summary>
        /// this is the execution method which gets executed later
        /// to get more arguments use the internal regArgs variable
        /// </summary>
        /// <param name="arg1">first argument after the command in the string</param>
        /// <param name="arg2">second argument after the command in the string</param>
        /// <param name="arg3">third argument after the command in the string</param>
        /// <param name="arg4">fourth argument after the command in the string</param>
        /// <returns>remember to set the command result in every return case</returns>
        public override CommandResult Execute(String arg1, String arg2, String arg3, String arg4)
        {
            Server.SendExecuteResponse(TriggerPlayer, ClientUser.LastEntityId.ToString());

            PacketGenerator gen = new PacketGenerator();
            gen.Add(ClientUser.LastEntityId);
            gen.Add(100);
            gen.Add(1000);
            gen.Add(100);
            gen.Add((byte)0);
            gen.Add((byte)0);

            ClientSocket c = Client as ClientSocket;
            (Server as ServerSocket).SendPacketToClient(PacketBytes._0x22_EntityTeleport_0x22, TriggerPlayer, gen.ToByteArray());

            XPosition pos = Client.Position;
            PacketGenerator teleportData = new PacketGenerator();
            teleportData.Add(100.0);// X
            teleportData.Add(999.5); // Y
            teleportData.Add(1000.0); // Stance
            teleportData.Add(100.0);  // Z
            teleportData.Add(pos.Rotation);
            teleportData.Add(pos.Pitch);
            teleportData.Add(pos.Unkown);
            Client.SendPacket(Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel.PacketBytes._0x0D_PlayerMoveAndLook_0x0D, teleportData.ToByteArray());


            (Server as ServerSocket).SendPacketToClient(PacketBytes._0x22_EntityTeleport_0x22, TriggerPlayer, gen.ToByteArray());

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
