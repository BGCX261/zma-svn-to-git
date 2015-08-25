using System;
using System.Collections.Generic;
using System.Text;

namespace Vitt.Andre.TCPTunnelLib.Vitt.Andre.Tunnel
{
    public enum PacketBytes
    {
        Minues_1 = -1,
        Null = 0,
        _0x00_KeepAlive_0x00 = 0x00,
        _0x01_Login_0x01 = 0x01,
        _0x02_Handshake_0x02 = 0x02,
        _0x03_Chat_0x03 = 0x03,
        _0x04_UpdateTime_0x04 = 0x04,
        _0x05_EntityEquipment_01_0x05 = 0x05,
        _0x06_SpawnPosition_02_0x06 = 0x06,
        _0x07_Use_Entity_0x07 = 0x07,
        _0x08_Health_0x08 = 0x08,
        _0x09_Respawn_0x09 = 0x09,
        _0x0A_Player_0x0A = 0x0A,
        _0x0B_PlayerPosition_0x0B = 0x0B,
        _0x0C_PlayerLook_0x0C = 0x0C,
        _0x0D_PlayerMoveAndLook_0x0D = 0x0D,
        _0x0E_BlockDig_0x0E = 0x0E,
        _0x0F_PlaceBlock_0x0F = 0x0F,
        _0x10_BlockItemSwitch_0x10 = 0x10,
        _0x11_UseBed_0x11 = 0x11,
        //_0x11_AddToInventory_0x11 = 0x11, removed
        _0x12_ArmAnimation_0x12 = 0x12,
        _0x13_NewPacket_0x13 = 0x13,
        _0x14_EntitySpawnName_0x14 = 0x14,
        _0x15_EntitySpawn_0x15 = 0x15,
        _0x16_CollectItem_0x16 = 0x16,
        _0x17_AddObject_0x17 = 0x17,
        _0x18_MobSpawn_0x18 = 0x18,
        _0x1B_NewPacket = 0x1B,
        _0x1C_EntityVelocity_0x1C = 0x1C,
        _0x1D_DestroyEntity_0x1D = 0x1D,
        _0x1E_Entity_0x1E = 0x1E,
        _0x1F_RelativeEntityMove_0x1F = 0x1F,
        _0x19_NewPacket_0x19 = 0x19,
        _0x20_EntityLook_0x20 = 0x20,
        _0x21_RelativeEntityLookAndMove_0x21 = 0x21,
        _0x22_EntityTeleport_0x22 = 0x22,
        _0x26_HitEntity_0x26 = 0x26,
        _0x27_AttachEntity_0x27 = 0x27,
        _0x28_NewPacket_0x28 = 0x28,
        _0x32_ChunkPre_0x32 = 0x32,
        _0x33_ChunkMap_0x33 = 0x33,
        _0x34_MultiBlockChange_0x34 = 0x34,
        _0x35_BlockChange_0x35 = 0x35,
        _0x36_BlockAction_0x36 = 0x36,
        //_0x3B_NewPacket_0x3B = 0x3B, removed
        _0x3C_Explosion_0x3C = 0x3C,
        _0x3D_SoundEffect_0x3D = 0x3D,
        _0x46_InvalidBed_0x46 = 0x46,
        _0x47_Weather_0x47 = 0x47,
        _0x64_OpenWindow_0x64 = 0x64,
        _0x65_CloseWindow_0x65 = 0x65,
        _0x66_WindowClick_0x66 = 0x66,
        _0x67_SetSlot_0x67 = 0x67, // special
        _0x68_WindowItems_0x68 = 0x68, // Complex
        _0x69_UpdateProgressBar_0x69 = 0x69, //Update progress bar (0x69) 
        _0x6A_Transaction_0x6A = 0x6A, //Transaction (0x6A) 
        _0x82_UpdateSign_0x82 = 0x82,
        _0x83_MapData_0x83 = 0x83,
        _0xC8_IncrementStatistics_0xC8 = 0xC8,
        _0xFF_Disconnect_0xFF = 0xFF
    };

    public enum PacketSizes
    {
        Minus_1 = -1,
        Minus_2 = -2,
        Null = 0,
        Array = -2,
        String = -1,
        Byte = 1,
        Bool = 1,
        Int16 = 2,
        Int32 = 4,
        Int64 = 8,
        Float = 4,
        Double = 8,
        _0x00_KeepAlive_0x00 = 0,
        _0x01_Login_0x01 = -1,
        _0x02_Handshake_0x02 = -1,
        _0x03_Chat_0x03 = -1,
        _0x04_UpdateTime_0x04 = 8,
        _0x05_EntityEquipment_01_0x05 = 10, // changed on update Beta 1.2 (2011-01-13) [8 => 10]
        _0x06_SpawnPosition_02_0x06 = 12,
        _0x07_Use_Entity_0x07 = 9,
        _0x08_Health_0x08 = 2,        
        _0x09_Respawn_0x09 = 1,
        _0x0A_Unkown01_0x0A = 1,
        _0x0B_PlayerPosition_0x0B = 33,
        _0x0C_PlayerLook_0x0C = 9,
        _0x0D_PlayerMoveAndLook_0x0D = 41,
        _0x0E_BlockDig_0x0E = 11,
        _0x0F_PlaceBlock_0x0F = -1,
        _0x10_BlockItemSwitch_0x10 = 2,
        _0x11_UseBed_0x11 = 14,
        //AddToInventory_0x11 = 5,
        _0x12_ArmAnimation_0x12 = 5,
        _0x13_NewPacket_0x13 = 5, // changed on update Beta 1.2 (2011-01-13) [int, byte]
        _0x14_EntitySpawnName_0x14 = -1,
        _0x15_EntitySpawn_0x15 = 24, // changed on update Beta 1.2 (2011-01-13) [22 => 24]
        _0x16_CollectItem_0x16 = 8,
        _0x17_Unkown02_0x17 = -1,
        _0x18_MobSpawn_0x18 = -1, // changed on update Beta 1.2 (2011-01-13) [18 => Insanity]
        _0x19_EntityPainting_0x19 = -1, // changed on update Beta 1.2 (2011-01-13) [int, string, int, int, int, int]
        _0x1B_NewPacket = 18,
        _0x1C_EntityVelocity_0x1C = 10,
        _0x1D_DestroyEntity_0x1D = 4,
        _0x1E_Entity_0x1E = 4,
        _0x1F_RelativeEntityMove_0x1F = 7,
        _0x20_EntityLook_0x20 = 6,
        _0x21_RelativeEntityLookAndMove_0x21 = 9,
        _0x22_EntityTeleport_0x22 = 18,
        _0x26_HitEntity_0x26 = 5,
        _0x27_AttachEntity_0x27 = 8,
        _0x28_EntityMetadata_0x28 = -1, // changed on update Beta 1.2 (2011-01-13) [int, byte] 
        _0x32_ChunkPre_0x32 = 9,
        _0x33_ChunkMap_0x33 = -1,
        _0x34_MultiBlockChange_0x34 = -1,
        _0x35_BlockChange_0x35 = 11,
        _0x3D_SoundEffect_0x3D = 17,
        _0x36_BlockAction_0x36 = 12, // changed on update Beta 1.2 (2011-01-13) [int, short, int, byte, byte] 12 Bytes 
        _0x3C_Explosion_0x3C = -1,//33 bytes + 3*(Record count) bytes , 
        _0x46_InvalidBed_0x46 = 1,
        _0x47_Weather_0x47 = 17,
        _0x64_OpenWindow_0x64 = -1,
        _0x65_CloseWindow_0x65 = 1,
        _0x66_WindowClick_0x66 = -1, // Special Implementation
        _0x67_SetSlot_0x67 = -1, // same
        _0x68_WindowItems_0x68 = -1, // Complex
        _0x69_UpdateProgressBar_0x69 = 5, //Update progress bar (0x69) 
        _0x6A_Transaction_0x6A = 4, //Transaction (0x6A) 
        _0x82_UpdateSign_0x82 = -1, // 10 + String
        _0x83_MapData_0x83 = -1,
        _0xC8_IncrementStatistics_0xC8 = 5,
        _0xFF_Disconnect_0xFF = -1
    };

    public class MinecraftEnums
    {
        public static PacketSizes GetPacketSize(PacketBytes firstByte)
        {
            switch (firstByte)
            {
                case PacketBytes.Minues_1:
                    return PacketSizes.Minus_1;
                case PacketBytes._0x00_KeepAlive_0x00:
                    return PacketSizes._0x00_KeepAlive_0x00;
                case PacketBytes._0x01_Login_0x01:
                    return PacketSizes._0x01_Login_0x01;
                case PacketBytes._0x02_Handshake_0x02:
                    return PacketSizes._0x02_Handshake_0x02;
                case PacketBytes._0x03_Chat_0x03:
                    return PacketSizes._0x03_Chat_0x03;
                case PacketBytes._0x04_UpdateTime_0x04:
                    return PacketSizes._0x04_UpdateTime_0x04;
                case PacketBytes._0x05_EntityEquipment_01_0x05:
                    return PacketSizes._0x05_EntityEquipment_01_0x05;
                case PacketBytes._0x06_SpawnPosition_02_0x06:
                    return PacketSizes._0x06_SpawnPosition_02_0x06;
                case PacketBytes._0x07_Use_Entity_0x07:
                    return PacketSizes._0x07_Use_Entity_0x07;
                case PacketBytes._0x08_Health_0x08:
                    return PacketSizes._0x08_Health_0x08;
                case PacketBytes._0x09_Respawn_0x09:
                    return PacketSizes._0x09_Respawn_0x09;
                case PacketBytes._0x0A_Player_0x0A:
                    return PacketSizes._0x0A_Unkown01_0x0A;
                case PacketBytes._0x0B_PlayerPosition_0x0B:
                    return PacketSizes._0x0B_PlayerPosition_0x0B;
                case PacketBytes._0x0C_PlayerLook_0x0C:
                    return PacketSizes._0x0C_PlayerLook_0x0C;
                case PacketBytes._0x0D_PlayerMoveAndLook_0x0D:
                    return PacketSizes._0x0D_PlayerMoveAndLook_0x0D;
                case PacketBytes._0x0E_BlockDig_0x0E:
                    return PacketSizes._0x0E_BlockDig_0x0E;
                case PacketBytes._0x0F_PlaceBlock_0x0F:
                    return PacketSizes._0x0F_PlaceBlock_0x0F;
                case PacketBytes._0x10_BlockItemSwitch_0x10:
                    return PacketSizes._0x10_BlockItemSwitch_0x10;
                case PacketBytes._0x11_UseBed_0x11:
                    return PacketSizes._0x11_UseBed_0x11;
                case PacketBytes._0x12_ArmAnimation_0x12:
                    return PacketSizes._0x12_ArmAnimation_0x12;
                case PacketBytes._0x13_NewPacket_0x13:
                    return PacketSizes._0x13_NewPacket_0x13;
                case PacketBytes._0x14_EntitySpawnName_0x14:
                    return PacketSizes._0x14_EntitySpawnName_0x14;
                case PacketBytes._0x15_EntitySpawn_0x15:
                    return PacketSizes._0x15_EntitySpawn_0x15;
                case PacketBytes._0x16_CollectItem_0x16:
                    return PacketSizes._0x16_CollectItem_0x16;
                case PacketBytes._0x17_AddObject_0x17:
                    return PacketSizes._0x17_Unkown02_0x17;
                case PacketBytes._0x18_MobSpawn_0x18:
                    return PacketSizes._0x18_MobSpawn_0x18;
                case PacketBytes._0x19_NewPacket_0x19:
                    return PacketSizes._0x19_EntityPainting_0x19;
                case PacketBytes._0x1B_NewPacket:
                    return PacketSizes._0x1B_NewPacket;
                case PacketBytes._0x1C_EntityVelocity_0x1C:
                    return PacketSizes._0x1C_EntityVelocity_0x1C;
                case PacketBytes._0x1D_DestroyEntity_0x1D:
                    return PacketSizes._0x1D_DestroyEntity_0x1D;
                case PacketBytes._0x1E_Entity_0x1E:
                    return PacketSizes._0x1E_Entity_0x1E;
                case PacketBytes._0x1F_RelativeEntityMove_0x1F:
                    return PacketSizes._0x1F_RelativeEntityMove_0x1F;
                case PacketBytes._0x20_EntityLook_0x20:
                    return PacketSizes._0x20_EntityLook_0x20;
                case PacketBytes._0x21_RelativeEntityLookAndMove_0x21:
                    return PacketSizes._0x21_RelativeEntityLookAndMove_0x21;
                case PacketBytes._0x22_EntityTeleport_0x22:
                    return PacketSizes._0x22_EntityTeleport_0x22;
                case PacketBytes._0x26_HitEntity_0x26:
                    return PacketSizes._0x26_HitEntity_0x26;
                case PacketBytes._0x27_AttachEntity_0x27:
                    return PacketSizes._0x27_AttachEntity_0x27;
                case PacketBytes._0x28_NewPacket_0x28:
                    return PacketSizes._0x28_EntityMetadata_0x28;
                case PacketBytes._0x32_ChunkPre_0x32:
                    return PacketSizes._0x32_ChunkPre_0x32;
                case PacketBytes._0x33_ChunkMap_0x33:
                    return PacketSizes._0x33_ChunkMap_0x33;
                case PacketBytes._0x34_MultiBlockChange_0x34:
                    return PacketSizes._0x34_MultiBlockChange_0x34;
                case PacketBytes._0x35_BlockChange_0x35:
                    return PacketSizes._0x35_BlockChange_0x35;
                case PacketBytes._0x36_BlockAction_0x36:
                    return PacketSizes._0x36_BlockAction_0x36;
                case PacketBytes._0x3C_Explosion_0x3C:
                    return PacketSizes._0x3C_Explosion_0x3C;
                case PacketBytes._0x3D_SoundEffect_0x3D:
                    return PacketSizes._0x3D_SoundEffect_0x3D;
                case PacketBytes._0x46_InvalidBed_0x46:
                    return PacketSizes._0x46_InvalidBed_0x46;
                case PacketBytes._0x47_Weather_0x47:
                    return PacketSizes._0x47_Weather_0x47; // Update 1.5 Weather
                case PacketBytes._0x64_OpenWindow_0x64:
                    return PacketSizes._0x64_OpenWindow_0x64;
                case PacketBytes._0x65_CloseWindow_0x65:
                    return PacketSizes._0x65_CloseWindow_0x65;
                case PacketBytes._0x66_WindowClick_0x66:
                    return PacketSizes._0x66_WindowClick_0x66;
                case PacketBytes._0x67_SetSlot_0x67:
                    return PacketSizes._0x67_SetSlot_0x67;
                case PacketBytes._0x68_WindowItems_0x68:
                    return PacketSizes._0x68_WindowItems_0x68;
                case PacketBytes._0x69_UpdateProgressBar_0x69:
                    return PacketSizes._0x69_UpdateProgressBar_0x69;
                case PacketBytes._0x6A_Transaction_0x6A:
                    return PacketSizes._0x6A_Transaction_0x6A;
                case PacketBytes._0x82_UpdateSign_0x82:
                    return PacketSizes._0x82_UpdateSign_0x82;
                case PacketBytes._0x83_MapData_0x83:
                    return PacketSizes._0x83_MapData_0x83;
                case PacketBytes._0xC8_IncrementStatistics_0xC8: // Update 1.5 Statistics
                    return PacketSizes._0xC8_IncrementStatistics_0xC8;
                case PacketBytes._0xFF_Disconnect_0xFF:
                    return PacketSizes._0xFF_Disconnect_0xFF;
                default:
                    return PacketSizes.Minus_2;
            }
        }
    }
}
