using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace Memory_game.Classes
{
    public static class Initialization_Of_Game
    {
        public static int[] screen_size(int card_amount)
        {
            switch (card_amount)
            {
                case 12:
                    return [850, 800];
                    break;
                case 18:
                    return [850, 1000];
                    break;
                case 24:
                    return [850, 1300];
                    break;
                case 30:
                    return [850, 1600];
                    break;
                case 36:
                    return [800, 1915];
                    break;
                case 48:
                    return [1055, 1900];
                    break;
                default:
                    return [0, 0];
                    break;
            }
        }
        public static void Checkstatus(Memory_Card flippedCard)
        {
            if (GlobalVars.first_Card != null && GlobalVars.second_Card != null)
            {
                GlobalVars.first_Card.InternalDeflip();
                GlobalVars.second_Card.InternalDeflip();
                GlobalVars.SetFirstCard(null);
                GlobalVars.SetSecondCard(null);
                GlobalVars.SetFirstCard(flippedCard);
                return;
            }
            if (GlobalVars.first_Card != null && GlobalVars.first_Card.Pic == flippedCard.Pic)
            {
                GlobalVars.first_Card.Viable = false;
                flippedCard.InternalDeflip();
                flippedCard.Viable = false;
                GlobalVars.SetFirstCard(null);
                GlobalVars.SetSecondCard(null);
                return;
            }
            if (GlobalVars.first_Card == null)
            {
                GlobalVars.SetFirstCard(flippedCard);
                return;
            }
            if (GlobalVars.second_Card == null)
            {
                GlobalVars.SetSecondCard(flippedCard);
                return;
            }
        }
        public static BitmapImage LoadImageFromResource(string resourceName)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var uri = new Uri(
                $"pack://application:,,,/{assemblyName};component/Resources/{resourceName}"
            );
            return new BitmapImage(uri);
        }
        public static List<Memory_Card> Setgame(int Amount)
        {
            var cards = new List<Memory_Card>();
            for (int i = 0; i < Amount; i++)
                cards.Add(new Memory_Card());
            cards = CastCards(cards);
            return cards;
        }
        public static List<Memory_Card> CastCards(List<Memory_Card> cards)
        {
            var positionArray = new int[cards.Count];
            var picArray = new int[cards.Count];
            var rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                positionArray[i] = i;
                if (i < cards.Count / 2)
                {
                    picArray[i] = i;
                    picArray[cards.Count - i - 1] = i;
                }
            }
            rand.Shuffle(positionArray);
            rand.Shuffle(picArray);
            var index = -1;
            foreach (Memory_Card card in cards)
            {
                index++;
                card.Posotion = positionArray[index];
                card.setPic(picArray[index].ToString());
            }
            return cards;
        }
    }
}
