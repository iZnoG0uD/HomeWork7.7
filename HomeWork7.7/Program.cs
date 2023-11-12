namespace HomeWork7._7
{
    abstract class Delivery
    {
        public string Address;
    }

    //Доставка на дом
    class HomeDelivery : Delivery
    {
        private DateTime TimetoDeliver;

    }

    //Доставка до постамата
    class PickPointDelivery : Delivery
    {
        private DateTime Delivered;
    }

    //Доставка до розничного магазина
    class ShopDelivery : Delivery
    {
        private DateTime Delivered;
    }

    class Order<TDelivery> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public Guid Id { get; }

        public int Number;

        public string Description;

        public bool IsCanceled { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

    }

    class OrderHistory
    {

        private List<Order<Delivery>> _history;

        public OrderHistory()
        {
            _history = new List<Order<Delivery>>();
        }

        public Order<Delivery> this[int index]
        {
            get
            {
                if (index >= 0 && index < _history.Count)
                {
                    return _history[index];
                }
                else
                {
                    return null;
                }
            }

        }

        public void Add(Order<Delivery> order)
        {
            _history.Add(order);
        }
       
        public void Remove(Guid orderId)
        {
            var order = _history.FirstOrDefault(x => x.Id == orderId);

            if (order != null)
            {
                _history.Remove(order);
            }
        }
    }



    abstract class Pay
    {
        protected string CardNumber;

        protected Pay(string cardData)
        {
            CardNumber = cardData;
        }
    }

    //Оплата в кредит или рассрочку
    class Credit : Pay
    {
        private bool IsBankApproval;

        private Credit(bool isbankApproval, string cardData) : base(cardData)
        {
            IsBankApproval = isbankApproval;
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