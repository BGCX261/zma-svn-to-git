using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
using Zicore.MinecraftAdmin;
using Zicore.MinecraftAdmin.Commands;
using Zicore.MinecraftAdmin.IO;

namespace MinecraftWrapper.AddonInterface
{
    public class AddonLoader
    {
        private AddonLoader(MinecraftHandler mc)
        {
            //pluginManager = new PluginManager("Plugins");
            //pluginManager.PluginsReloaded += new EventHandler(pluginManager_PluginsReloaded);
            //pluginManager.Start();
        }

        void pluginManager_PluginsReloaded(object sender, EventArgs e)
        {
            //foreach (string pluginObjectName in
            //    pluginManager.GetSubclasses(typeof(MarshalByRefObject).FullName))
            //{
            //    MarshalByRefObject pluginObject = pluginManager.CreateInstance(
            //        pluginObjectName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance,
            //        new object[] { });
            //    IPlugin plugin = pluginObject as IPlugin;
            //    if (plugin != null)
            //    {
            //        this.Plugins.Add(plugin);
            //    }
            //}
        }

        //public void LoadPlugins()
        //{
        //    pluginManager.PluginSources = PluginSourceEnum.DynamicAssemblies;
        //    pluginManager.ReloadPlugins();
        //}

        private static volatile AddonLoader instance = null;
        private static object m_lock = new object();

        public static AddonLoader GetInstance(MinecraftHandler mc)
        {
            // DoubleLock
            if (instance == null)
            {
                lock (m_lock)
                {
                    if (instance == null)
                    {
                        instance = new AddonLoader(mc);
                    }
                }
            }
            instance.LoadAddons(mc);
            return instance;
        }

        PluginCollection plugins = new PluginCollection();

        public PluginCollection Plugins
        {
            get { return plugins; }
            set { plugins = value; }
        }

        //public List<String> GetPossibleAddons()
        //{
        //    List<String> addons = new List<string>();

        //    string path = Config.PluginFolder;
        //    if (Directory.Exists(path))
        //    {
        //        try
        //        {
        //            string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
        //            foreach (string dir in dirs)
        //            {
        //                string[] addonFiles = Directory.GetFiles(dir, "*.dll", SearchOption.TopDirectoryOnly);
        //                foreach (string str in addonFiles)
        //                {
        //                    Assembly bibliothek = Assembly.LoadFile(str);
        //                    if (str == "MinecraftWrapper.dll")
        //                        continue;

        //                    foreach (Type typ in bibliothek.GetExportedTypes())
        //                    {
        //                        if (typeof(IPlugin).IsAssignableFrom(typ))
        //                        {
        //                            addons.Add(str);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            if (ex.InnerException != null)
        //            {
        //                if (ex.InnerException.InnerException != null)
        //                {
        //                    MessageBox.Show("Couln't load addons: AddonLoader.LoadAddons()\n" + ex.InnerException.InnerException.Message);
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Couln't load addons: AddonLoader.LoadAddons()\n" + ex.InnerException.Message);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Couln't load addons: AddonLoader.LoadAddons()\n" + ex.Message);
        //            }
        //        }
        //    }
        //    return addons;
        //}

        Dictionary<String, String> paths = new Dictionary<string, string>();

        public void LoadAddons(MinecraftHandler mc)
        {
            paths.Clear();
            AppDomain.CurrentDomain.AssemblyResolve -= new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            string path = Config.PluginFolder;
            if (Directory.Exists(path))
            {
                try
                {
                    string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                    foreach (string dir in dirs)
                    {
                        string[] addonFiles = Directory.GetFiles(dir, "*.dll", SearchOption.TopDirectoryOnly);
                        foreach (string str in addonFiles)
                        {
                            try
                            {
                                Assembly bibliothek = Assembly.LoadFile(str);
                                if (str == "MinecraftWrapper.dll")
                                    continue;
                                
                                foreach (Type typ in bibliothek.GetExportedTypes())
                                {
                                    try
                                    {
                                        if (typeof(IPlugin).IsAssignableFrom(typ))
                                        {
                                            try
                                            {
                                                try
                                                {
                                                    paths.Add(typ.FullName, dir);
                                                }
                                                catch { }
                                                IPlugin plugin = typ.Assembly.CreateInstance(typ.FullName) as IPlugin;
                                                plugin.StartUpPath = str;
                                                plugin.OnPluginLoaded(CommandManager.GetInstance(mc) as ICommandManager, mc);
                                                plugins.Add(plugin);
                                                
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Couln't load addon: " + str + Environment.NewLine + ex.Message);
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        Log.Append(this, "Couldn't load an addon", Log.ExceptionsLog);
                                    }
                                }
                            }
                            catch
                            {
                                Log.Append(this, "Couldn't load an addon", Log.ExceptionsLog);
                            }
                        }
                    }
                }
                catch
                {
                    Log.Append(this, "Couldn't load an addon", Log.ExceptionsLog);
                }
            }
        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            String fileName = args.Name.Split(',')[0];
            
            foreach (String file in Directory.GetFiles("Plugins","*.dll", SearchOption.AllDirectories))
            {
                if (file.ToLower().Contains(fileName.ToLower()))
                {
                    return Assembly.LoadFrom(file);
                }
                
            }
            
            return null;
        }
    }
}
