using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftWrapper.AddonInterface
{
    public interface IPlugin : IActions
    {
        bool Enabled { get; set; }
        String Description { get; set; }
        String StartUpPath { get; set; }
    }
}
