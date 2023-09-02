﻿namespace BookStore.Books.Model
{
    public class BookEditModel
    {
        public string BookName { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public float DiscountPrice { get; set; }
        public float ActualPrice { get; set; }
    }
}
