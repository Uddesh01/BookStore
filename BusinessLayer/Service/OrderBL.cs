//using BusinessLayer.Interface;
//using RepositoryLayer.Entitys;
//using RepositoryLayer.Interface;

//namespace BusinessLayer.Service
//{
//    public class OrderBL : IOrderBL
//    {
//        private readonly IOrderRL iorderRL;
//        public OrderBL(IOrderRL orderRL)
//        {
//            iorderRL = orderRL;
//        }
//        OrderEntity IOrderBL.AddOrder(long bookId, int quantitys, long userId)
//        {
//           return iorderRL.AddOrder(bookId, quantitys, userId);
//        }
//    }
//}
