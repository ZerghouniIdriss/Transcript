using Newtonsoft.Json;
using Serilog.Formatting.Compact;
using Serilog;
using TransGr8_DD_Test.Services;
using TransGr8_DD_Test.Common.Utilities;
using TransGr8_DD_Test.BLL;
using TransGr8_DD_Test.Models;

namespace TransGr8_DD_Test
{
    public class Program
    {
        public static Logger logger = Logger.Instance;

        static void Main(string[] args)
        {
 

            // Create a user with some attributes.
             List<Spell> spells = new List<Spell>();
            spells.Add(new Spell
            {
                Name = "Fireball",
                Level = 3,
                CastingTime = "1 action",
                Components = "V, S, M (a tiny ball of bat guano and sulfur)",
                Range = 150,
                Duration = "Instantaneous",
                SavingThrow = "Dexterity"
            });
            spells.Add(new Spell
            {
                Name = "Magic Missile",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 120,
                Duration = "Instantaneous",
                SavingThrow = ""
            });
            spells.Add(new Spell
            {
                Name = "Cure Wounds",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 1,
                Duration = "Instantaneous",
                SavingThrow = ""
            });


            string spellName = args[0];
            // Use the spell checker to determine if the user can cast the spell.
            SpellChecker spellChecker = new SpellChecker(spells);

            //Get the user from Datasource (could be from json, persistant, cash, memory ...)
            IUserRepository userService = new UserRepository();
            List<User> users = userService.GetAllUsers();

            logger.Information("Enter the index of the user to check the spell for:");
            int index = int.Parse(Console.ReadLine());

            User selectedUser = users[index];
            bool canCast = spellChecker.CanUserCastSpell(selectedUser, spellName);

            logger.Information("Can the user cast {SpellName}? {CanCast}", spellName, canCast);


        }
    }
}