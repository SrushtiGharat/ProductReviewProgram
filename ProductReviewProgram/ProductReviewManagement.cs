using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewProgram
{
    class ProductReviewManagement
    {
        public readonly DataTable dataTable = new DataTable();
        /// <summary>
        /// Get top 3 best rated products
        /// </summary>
        /// <param name="listProductReview"></param>
        public void GetTopBestRatedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID : " + list.ProductID + " " + "UserID : " + list.UserID
                    + " " + "Rating : " + list.Rating + " " + "Review : " + list.Review + " " + "isLike : " + list.isLike);
            }
        }

        /// <summary>
        /// Get products with id 1,4 or 9 having rating >3
        /// </summary>
        /// <param name="listProductReview"></param>
        public void RatingsGreaterThanThreeOfSpecificProducts(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview
                               where (productReview.ProductID == 1 || productReview.ProductID == 4 || productReview.ProductID == 9)
                               && productReview.Rating > 3
                               select productReview;
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID : " + list.ProductID + " " + "UserID : " + list.UserID
                    + " " + "Rating : " + list.Rating + " " + "Review : " + list.Review + " " + "isLike : " + list.isLike);
            }
        }

        /// <summary>
        /// Get review counts for each product id
        /// </summary>
        /// <param name="listProductReview"></param>
        public void GetCountOfReviews(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "-->" + list.Count);
            }
        }

        /// <summary>
        /// Get only product id and reviews from the list
        /// </summary>
        /// <param name="listProductReview"></param>
        public void GetProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview select new { productReview.ProductID, productReview.Review };

            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "-->" + list.Review);
            }
        }

        /// <summary>
        /// Skip Top 5 Records
        /// </summary>
        /// <param name="listProductReview"></param>
        public void SkipTop5Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview select productReview).Skip(5);

            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID : " + list.ProductID + " " + "UserID : " + list.UserID
                    + " " + "Rating : " + list.Rating + " " + "Review : " + list.Review + " " + "isLike : " + list.isLike);
            }
        }

        /// <summary>
        /// Insert values in data table from list
        /// </summary>
        /// <param name="listProductReview"></param>
        public void InsertValuesInDataTable(List<ProductReview> listProductReview)
        {
            dataTable.Columns.Add("ProductID");
            dataTable.Columns.Add("UserID");
            dataTable.Columns.Add("Rating");
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike");

            foreach(ProductReview product in listProductReview)
            {
                dataTable.Rows.Add(product.ProductID, product.UserID, product.Rating, product.Review, product.isLike);
            }          
        }
    }
}
