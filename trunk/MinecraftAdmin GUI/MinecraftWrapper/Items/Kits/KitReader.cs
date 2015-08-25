using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace Zicore.MinecraftAdmin
{
    public class KitReader
    {
        public static String File = "Kits.xml";


        //public static Kit GetKitFromName(String file, String filter)
        //{
        //    try
        //    {
        //        Kit kit = new Kit();

        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(file);

        //        XmlNode root = doc["root"];
        //        XmlNode kits = root["kits"];

        //        foreach (XmlNode n in kits)
        //        {
        //            int level = 0;
        //            string name = null;
        //            bool fixedGroup = false;
        //            try
        //            {
        //                name = n.Attributes["name"].Value;
        //            }
        //            catch{ }
        //            try
        //            {
        //                string value = n.Attributes["level"].Value;
        //                level = Convert.ToInt32(value);
        //            } 
        //            catch { }

        //            try
        //            {
        //                fixedGroup = Convert.ToBoolean(n.Attributes["fixedgroup"].Value);
        //            }
        //            catch { }

        //            if (String.IsNullOrEmpty(name) || filter != name)
        //                continue;

        //            kit.Name = name;
        //            kit.Level = level;
        //            kit.FixedGroup = fixedGroup;

        //            foreach (XmlNode i in n)
        //            {
        //                string id = null;
        //                int amount = 1;
        //                try
        //                {
        //                    id = i.Attributes["id"].Value;
        //                }
        //                catch
        //                {
        //                    continue;
        //                }
        //                try
        //                {
        //                    amount = int.Parse(i.Attributes["amount"].Value);
        //                }
        //                catch
        //                {

        //                }

        //                KitItem item = new KitItem(id, amount);
        //                kit.Items.Add(item);
        //            }
        //            return kit;
        //        }
        //        return null;
        //    }
        //    catch (Exception)
        //    {                
        //        throw;
        //    }
        //}

        public static List<Kit> GetKitlist(String file)
        {
            List<Kit> kitlist = new List<Kit>();
            try
            {
               

                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                XmlNode root = doc["root"];
                XmlNode kits = root["kits"];

                foreach (XmlNode n in kits)
                {
                    int level = 0;
                    string name = null;
                    bool fixedGroup = false;
                    try
                    {
                        name = n.Attributes["name"].Value;
                    }
                    catch { }
                    try
                    {
                        string value = n.Attributes["level"].Value;
                        level = int.Parse(value);
                    }
                    catch { }
                    try
                    {
                        fixedGroup = Convert.ToBoolean(n.Attributes["fixedgroup"].Value);
                    }
                    catch { }

                    Kit kit = new Kit();

                    kit.Name = name;
                    kit.Level = level;
                    kit.FixedGroup = fixedGroup;

                    foreach (XmlNode i in n)
                    {
                        string id = null;
                        int amount = 1;
                        try
                        {
                            id = i.Attributes["id"].Value;
                        }
                        catch
                        {
                            continue;
                        }
                        try
                        {
                            amount = int.Parse(i.Attributes["amount"].Value);
                        }
                        catch
                        {

                        }

                        KitItem item = new KitItem(id, amount);
                        kit.Items.Add(item);
                    }
                    kitlist.Add(kit);
                }

            }
            catch (Exception ex)
            {
                throw ex;   
            }
            return kitlist;
        }

        public static void SaveKitlist(List<Kit> kitlist, String file)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                XmlNode root = doc.CreateElement("root");
                doc.AppendChild(root);

                XmlNode kits = doc.CreateElement("kits");
                root.AppendChild(kits);

                foreach (Kit kit in kitlist)
                {
                    XmlNode kitNode = doc.CreateElement("kit");
                    XmlAttribute atr = doc.CreateAttribute("name");
                    atr.Value = kit.Name;
                    kitNode.Attributes.Append(atr);

                    atr = doc.CreateAttribute("level");
                    atr.Value = kit.Level.ToString();
                    kitNode.Attributes.Append(atr);

                    atr = doc.CreateAttribute("fixedgroup");
                    atr.Value = kit.FixedGroup.ToString();
                    kitNode.Attributes.Append(atr);

                    foreach (KitItem item in kit.Items)
                    {
                        XmlNode kitItemNode = doc.CreateElement("item");
                        atr = doc.CreateAttribute("id");
                        atr.Value = item.Id;
                        kitItemNode.Attributes.Append(atr);

                        atr = doc.CreateAttribute("amount");
                        atr.Value = item.Amount.ToString();
                        kitItemNode.Attributes.Append(atr);

                        kitNode.AppendChild(kitItemNode);
                    }

                    kits.AppendChild(kitNode);
                }

                doc.Save(file);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"couldn't save " + file);
            }
        }
    }
}
