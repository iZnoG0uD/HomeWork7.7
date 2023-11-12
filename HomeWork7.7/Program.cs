namespace HomeWork7._7
{
    abstract class Delivery
    {
        public string Address;
    }

    //Доставка на дом
    class HomeDelivery : Delivery
    {
        private string AddresstoDeliver;
        private DateTime TimetoDeliver;

    }

    //Доставка до постамата
    class PickPointDelivery : Delivery
    {
        private string AddressToDeliver;
        private DateTime Delivered;
    }

    //Доставка до розничного магазина
    class ShopDelivery : Delivery
    {
        private string AddressToDeliver;
        private DateTime Delivered;
    }

    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }


    }

    class CancelOrder
    {

    }

    class Orders
    {
        public int Number;
        public string Description;
    }

    class OrderHistory
    {
        private Orders[] history;

        public OrderHistory(Orders[] history)
        {
            this.history = history;
        }

        public Orders this[int index]
        {
            get
            {
                if (index >= 0 && index < history.Length)
                {
                    return history[index];
                }
                else
                {
                    return null;
                }
            }

            private set
            {
                if (index >= 0 && index < history.Length)
                {
                    history[index] = value;
                }
            }

        }
    }



    abstract class Pay
    {
        protected string CardData;

        protected Pay(string cardData)
        {
            CardData = cardData;
        }
    }

    //Оплата в кредит или рассрочку
    class Credit : Pay 
    {
        private bool BankApproval;

        private Credit(bool bankApproval, string cardData) : base(cardData)
        {
            BankApproval = bankApproval;
        }
    }

    //Полная предоплата
    class PreOrder : Pay 
    {
        private bool IsPayed;

        private PreOrder(string cardData, bool isPayed) : base(cardData)
        {
            IsPayed = isPayed;   
        } 
    }

    //Оплата при получении
    class OnArrival : Pay 
    {
        private bool IsPayed; 

        private OnArrival(bool isPayed, string cardData) : base(cardData)
        {
            IsPayed = isPayed;
        }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}