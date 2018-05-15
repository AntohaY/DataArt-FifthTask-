namespace RevercePOCO
{

    
    public partial class Card
    {
        public string CardId { get; set; } // CardID (Primary key) (length: 16)
        public int ClientId { get; set; } // ClientID
        public string PinCode { get; set; } // PinCode (length: 4)
        public decimal Ballance { get; set; } // Ballance

       
        public System.Collections.Generic.ICollection<Operation> Operations_In { get; set; } 
       
        public System.Collections.Generic.ICollection<Operation> Operations_Out { get; set; }

        

        
        public Client Client { get; set; } 

        public Card()
        {
            PinCode = "0";
            Ballance = 0m;
            Operations_Out = new System.Collections.Generic.List<Operation>();
            Operations_In = new System.Collections.Generic.List<Operation>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

