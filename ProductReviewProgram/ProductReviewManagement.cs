using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductReviewProgram
{
    class ProductReviewManagement
    {
        public void TopBestRatedRecords(List<ProductReview> listProductReview)
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
    }
}
