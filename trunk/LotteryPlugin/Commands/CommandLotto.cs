using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using MinecraftWrapper.AddonInterface;
using ZmaGamAzzLottoPlugin;
using Vitt.Andre.XML;
using System.IO;
using Zicore.MinecraftAdmin.Admins;

namespace Zicore.MinecraftAdmin.Commands
{
    /// <summary>
    /// make sure it inherits the Command class
    /// </summary>
    public class CommandLotto : Command
    {
        /// <summary>
        /// the string for the base class is the name of this command
        /// it gets executed with !color then, should be the same like the in the register method
        /// </summary>
        /// <param name="mc">The minecraft handler</param>
        public CommandLotto(IMinecraftHandler mc)
            :base(mc,"lotto")
        {
            Help = "Participates lotto by entering a number";
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
            try
            {
                ConfigLotto config = ConfigLotto.Load();
                LottoUserCollection _lottoUsers = XObject<LottoUserCollection>.Load(ConfigLotto.ConfigFolder + ConfigLotto.LottoFile);
                UserCollectionSingletone users = UserCollectionSingletone.GetInstance();

                if (ClientUser != null && ClientUser.LevelID != 0)
                {
                    if (!_lottoUsers.IsInList(TriggerPlayer))
                    {
                        if (ClientUser.Balance >= config.Price)
                        {
                            try
                            {
                                ClientUser.Balance -= config.Price;
                                int zahl = Convert.ToInt32(arg1);
                                if (zahl >= config.Min && zahl <= config.Max)
                                {
                                    LottoUser lottouser = new LottoUser(TriggerPlayer, zahl);
                                    _lottoUsers.Add(lottouser);
                                    _lottoUsers.Jackpot += config.Price;
                                    _lottoUsers.Save();
                                    Server.SendExecuteResponse(TriggerPlayer, string.Format("§{0}Your lucky number is §6{1}", MinecraftHandler.Config.ResponseColorChar, zahl));
                                    return new CommandResult(true, string.Format("{0} participates lotto!", TriggerPlayer));

                                }
                                else
                                {
                                    Server.SendExecuteResponse(TriggerPlayer, string.Format("Number must be between {0} - {1}", config.Min, config.Max));
                                }
                            }
                            catch
                            {
                                Server.SendExecuteResponse(TriggerPlayer, string.Format("Entered a wrong number!"));
                            }

                        }
                        else
                        {
                            Server.SendExecuteResponse(TriggerPlayer, string.Format("Not enough money!"));
                        }
                    }
                    else
                    {
                        Server.SendExecuteResponse(TriggerPlayer, string.Format("Allready participated!"));
                    }
                }
                else
                {
                    Server.SendExecuteResponse(TriggerPlayer, string.Format("You have no giro account!"));
                }
            }
            catch
            {
                Server.SendExecuteResponse(TriggerPlayer, string.Format("Lotto User list not found"));
            }
           

            return new CommandResult(true, string.Format("{0} executed by {1}", Name, TriggerPlayer));
        }
    }
}
