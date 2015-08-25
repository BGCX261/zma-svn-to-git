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
    public class CommandJackpot : Command
    {
        /// <summary>
        /// the string for the base class is the name of this command
        /// it gets executed with !color then, should be the same like the in the register method
        /// </summary>
        /// <param name="mc">The minecraft handler</param>
        public CommandJackpot(IMinecraftHandler mc)
            : base(mc, "jackpot")
        {
            Help = "Shows the current lottery jackpot";
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
                return new CommandResult(true, string.Format("The current Jackpot is §6{0} {1}", _lottoUsers.Jackpot, MinecraftHandler.Config.CurrencySymbol));
            }
            catch
            {
                return new CommandResult(true, string.Format("Lotto User list not found"));
            }
        }
    }
}