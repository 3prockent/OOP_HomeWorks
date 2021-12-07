using System;
namespace Inteface
{
    class Content
    {
        interface IItem
        {
            void ApplyDiscount(String discount);
            void ApplyPromocode(String promocode);


            void SetColor(byte color);
            void SetSize(byte size);
            void SetPrice(double price);
        }

    }
    class Book : Content
    {
        private string _title;
        private string _author;
        private string _publisherName;
        private uint _pageQuantity;
        private uint _publicationDate;
        public Book(string title)
               : this(title, string.Empty, string.Empty, 1u, 0u)
        {
        }

        public Book(string title, string author)
            : this(title, author, string.Empty, 1u, 0u)
        {
        }

        public Book(string title, string author, string publisherName, uint pageQuantity, uint publicationDate)
        {
            Title = title;
            Author = author;
            Publisher = publisherName;
            PageQuantity = pageQuantity;
            PublicationDate = publicationDate;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public uint PageQuantity { get; set; }
        public uint PublicationDate { get; set; }
    }
    class Clothes : Content {
        private string label { get; set; }
        private string material { get; set; }
        private uint size { get; set; }
        private uint price { get; set; }


        public Clothes(string _label, string _material, uint _size, uint _price) 
        {
            Label = _label;
            Material = _material;
            Size = _size;
            Price = _price;

        }
        public string Label { get; set; }
        public string Material { get; set; }
        public uint Size { get; set;  }
        public uint Price { get; set;  }
    }

}
