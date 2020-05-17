using System;
using System.Collections.Generic;
using Game.Engine.Skills.SkillFactories;
using Game.Engine.Monsters.MonsterFactories;
using Game.Engine.Items;
using Game.Engine.Items.ItemFactories;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Interactions;
using Game.Engine.Interactions.InteractionFactories;
using Game.Engine.Items.BasicRing;
using Game.Engine.Items.Amulet;
using Game.Engine.Items.OsirisArmor;

namespace Game.Engine
{
    // contains information about skills, items and monsters that will be available in the game
    public partial class Index
    {
        private static List<SkillFactory> magicSkillFactories = new List<SkillFactory>()
        {
            new BasicSpellFactory(),
            new WaterSpellFactory(), 
            new OsirisMovesFactory(),
            new AdvancedSpellsFactory1(),
            new AdvancedSpellsFactory2(),
            new ArmorDerivedSpellFactory()
        };

        private static List<SkillFactory> weaponSkillFactories = new List<SkillFactory>()
        {
            new BasicWeaponMoveFactory(),
            new AxeCutFactory(),
            new SwordMoveFactory(),
            new SpearMoveFactory(),
            new ArmorDerivedSpellFactory()
        };

        private static List<Item> items = new List<Item>()
        {
            new BasicStaff(),
            new BasicSpear(),
            new BasicAxe(),
            new BasicSword(),
            new SteelArmor(),
            new AntiMagicArmor(),
            new BerserkerArmor(),
            new GrowingStoneArmor(),
            new CrystalSword(),
            new InfinitySword(),
            new MoonlightSword(),
            new ArmorRing(),
            new HealthRing(),
            new MagicRing(),
            new LuckyCharmAmulet(),
            new MageDuelistAmulet(),
            new SupportingAmulet(),
            new OsirisEye(),
            new OsirisSabre(),
            new OsirisStaff()
        };

        private static List<ItemFactory> itemFactories = new List<ItemFactory>()
        {
            new BasicArmorFactory(),
            new SwordFactory(),
            new BasicRingFactory(),
            new AmuletFactory(),
            new OsirisFactory()
        };

        private static List<MonsterFactory> monsterFactories = new List<MonsterFactory>()
        {
            // x3
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.RatFactory(),
            new Monsters.MonsterFactories.BatFactory(),
            new Monsters.MonsterFactories.BatFactory(),
            new Monsters.MonsterFactories.BatFactory(),
            // x2
            new Monsters.MonsterFactories.ButterflyFactory(),
            new Monsters.MonsterFactories.ButterflyFactory(),
            // x1
            new Monsters.MonsterFactories.EgyptMonstersFactory(),
            new Monsters.MonsterFactories.GolemFactory(),
            new Monsters.MonsterFactories.MimicFactory(),
            new Monsters.MonsterFactories.PhoenixFactory(),
            new Monsters.MonsterFactories.UnicornFactory(),
            new Monsters.MonsterFactories.GermFactory(),
            new Monsters.MonsterFactories.IceDragonFactory(),
            new Monsters.MonsterFactories.HydraFactory(),
            new Monsters.MonsterFactories.UnseenHorrorFactory()
        };

        private static List<InteractionFactory> interactionFactories = new List<InteractionFactory>()
        {
            new SkillForgetFactory(),
            new GymirHymirFactory()
        };

    }
}
