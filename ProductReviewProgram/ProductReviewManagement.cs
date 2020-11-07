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
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count()});
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
            dataTable.Columns.Add("ProductID",typeof(int));
            dataTable.Columns.Add("UserID",typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike", typeof(bool));

            foreach(ProductReview product in listProductReview)
            {
                dataTable.Rows.Add(product.ProductID, product.UserID, product.Rating, product.Review, product.isLike);
            }          
        }

        /// <summary>
        /// Get records with isLike true from data table
        /// </summary>
        public void GetRecordsWithIsLikeTrue()
        {
            var recordedData = from productReview in dataTable.AsEnumerable() where productReview.Field<bool>("isLike") == true
                               select productReview;

            foreach (var product in recordedData)
            {
                Console.WriteLine("ProductID : " + product.Field<int>("ProductID") + " " + "UserID : " + product.Field<int>("UserID")
                    + " " + "Rating : " + product.Field<double>("Rating") + " " + "Review : " + product.Field<string>("Review") + " " 
                    + "isLike : " + product.Field<bool>("isLike"));
            }
        }

        public void GetAverageRating()
        {
            var recordedData = dataTable.AsEnumerable().GroupBy(e => e.Field<int>("ProductID")).Select 
                               (x => new { ProductID = x.Key, Average = x.Average(y => y.Field<double>("Rating"))});

            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "-->" + list.Average);
            }
        }
    }
}
