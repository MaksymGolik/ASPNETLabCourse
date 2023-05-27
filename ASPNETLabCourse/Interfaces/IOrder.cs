using ASPNETLabCourse.Models;

namespace ASPNETLabCourse.Interfaces
{
    public interface IOrder
    {
        void createOrder(Order order);
        Order GetOrderById(int Id);

    }
}
