using RevercePOCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FluentApi.Services
{
    public class DbService
    {
        public void InsertInitialData()
        {
            using (var ctx = new MyDbContext())
            {
                var newClient = new Client
                {
                    FirstName = "John",
                    LastName = "Ivanovich",
                    Birthday = DateTime.Parse("1989-05-06"),
                    Phone = "+380 (067) 123 22 33"
                };
                var card1 = new Card { CardId = "5234567811111111", PinCode = "5241" };
                newClient.Cards.Add(card1);
                var card2 = new Card { CardId = "5930655411111112", PinCode = "8752" };
                newClient.Cards.Add(card2);

                ctx.Clients.Add(newClient);

                ctx.Operations.Add(new Operation { Amount = 100, In = card2, Out = card1 });

                ctx.SaveChanges();
            }
        }

        public void RecalculateBallance(string cardNo)
        {
            using(var ctx = new MyDbContext())
            {
                var card = ctx.Cards.SingleOrDefault(c => c.CardId == cardNo);
           

                ctx.Entry(card).Collection(c => c.Operations_In).Load();
                ctx.Entry(card).Collection(c => c.Operations_Out).Load();

                card.Ballance = 
                    card.Operations_In.Sum(o => o.Amount) - card.Operations_Out.Sum(o => o.Amount);

                ctx.SaveChanges();
            }
        }
    }
}
