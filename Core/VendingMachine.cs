using System.Linq;
namespace Core
{
    public class VendingMachine
    {
        public int OnePenny { get; set; }
        private int onePenny;
        public int FivePens { get; set; }
        private int fivePens;
        public int TenPens { get; set; }
        private int tenPens;
        public int TwentyPens { get; set; }
        private int twentyPens;
        public int FiftyPens { get; set; }
        private int fiftyPens;
        public int OnePounds { get; set; }
        private int onePounds;
        public float GrandTotal { get; set; }
        private FoodStore store; 

        public FoodStore Store
        {
            get {
                return store;
            }
            set {
                store = value;
            }
        }
        public VendingMachine(int qPenny, int qFivep, int qTenp, int qTwentyp, int qFiftyp, int qonePound)
        {
            OnePenny = qPenny;
            onePenny = qPenny;
            FivePens = qFivep;
            fivePens = qFivep;
            TenPens = qTenp;
            tenPens = qTenp;
            TwentyPens = qTwentyp;
            twentyPens = qTwentyp;
            FiftyPens = qFiftyp;
            fiftyPens = qFiftyp;
            OnePounds = qonePound;
            onePounds = qonePound;
            TotalMoney();          
            Store=new FoodStore();
        }
        private void TotalMoney()
        {
            GrandTotal = (0.01F * OnePenny + FivePens * 0.05F + TenPens * 0.1F + TwentyPens * 0.2F + FiftyPens * 0.50F + OnePounds * 1.00F);
        }

        private void  UpdateVendingMachine(string[] coins,string itemBought,int nitems)
        {
            FoodItem fd = FoodStore.foodStorage.FirstOrDefault(m => m.Name.Equals(itemBought));

            float money = 0;
            foreach (var coin in coins)
            {
                switch (coin)
                {
                    case "OnePenny":
                        onePenny++;
                        money += 0.01F;
                        break;
                    case "FivePens":
                        fivePens++;
                        money += 0.05F;
                        break;
                    case "TenPens":
                        tenPens++;
                        money += 0.10F;
                        break;
                    case "TwentyPens":
                        twentyPens++;
                        money += 0.20F;
                        break;
                    case "FiftyPens":
                        fiftyPens++;
                        money += 0.50F;
                        break;
                    case "OnePound":
                        onePounds++;
                        money += 1.00F;
                        break;
                }

            }            
                     
                    if ((fd.Price * nitems).Equals((money)))
                    {   //Money is sufficient here                       
                        fd.Quantity -= nitems;               
                        OnePenny = onePenny;
                        FivePens = fivePens;
                        TenPens = tenPens;
                        TwentyPens = twentyPens;
                        FiftyPens = fiftyPens;
                        OnePounds = onePounds;
                    }

                    else if ((fd.Price * nitems) < money)
                    {
                       // GrandTotal -= money;
                        fd.Quantity -= nitems;
                        OnePenny = onePenny;
                        FivePens = fivePens;
                        TenPens = tenPens;
                        TwentyPens = twentyPens;
                        FiftyPens = fiftyPens;
                        OnePounds = onePounds;
                        //change is due here
                        int change = System.Convert.ToInt32((money - fd.Price * nitems)*100);
                        GiveChange(change);
                    }

                    else
                    {
                        // Money is not sufficient here we reestabilish the original situation 
                        onePenny = OnePenny;
                        fivePens=FivePens;
                        tenPens=TenPens;
                        twentyPens=TwentyPens;
                        fiftyPens= FiftyPens;
                        OnePounds = onePounds;
                        return;  
                    }
        }


        private void GiveChange(int change)
        {
            switch (change)
            {
                case 1:
                    onePenny--;
                    OnePenny = onePenny;
                    break;
                case 2:
                    onePenny-=2;
                    OnePenny = onePenny;
                    break;
                case 5:
                    fivePens--;
                    FivePens = fivePens;
                    break;
                case 10:
                    tenPens--;
                    TenPens = tenPens;                   
                    break;
                case 15:
                    tenPens--;
                    fivePens--;
                    TenPens = tenPens;
                    FivePens = fivePens;
                    break;
                case 20:
                    twentyPens--;
                    TwentyPens = twentyPens;
                    break;
                case 25:
                    twentyPens--;
                    TwentyPens = twentyPens;
                    fivePens--;                  
                    FivePens = fivePens;
                    break;
                case 50:
                    fiftyPens--;
                    FiftyPens = fiftyPens;                   
                    break;
                case 100:
                    onePounds--;
                    OnePounds = onePounds;                  
                    break;
                default:
                break;
            }

        }
        
        public void Purchase(int numOfItems,string itemName,string [] coins)
        {
            FoodItem fd = FoodStore.foodStorage.FirstOrDefault(m => m.Name.Equals(itemName));
            if (fd.Quantity - numOfItems < 0) return;
            UpdateVendingMachine(coins, itemName, numOfItems);
        }     


    }
}
