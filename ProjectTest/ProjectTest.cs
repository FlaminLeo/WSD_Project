using System;
using System.Collections.Generic;
using System.Text;
using WSD_Project_C2004V_4.Models;
using Xunit;

namespace ProjectTest
{
    public class ProjectTest
    {
        [Fact]
        public void CanChangeOrderTitle()
        {
            // Arrange
            var orderDetail = new Order { FoodDescription = "Mee goreng", OrderQuantity = 1 };
            // Act 
            orderDetail.FoodDescription = "New Title";
            // Assert
            Assert.Equal("New Title", orderDetail.FoodDescription);
        }

        [Fact]
        public void CanChangeOrderQuantity()
        {
            // Arrange
            var orderDetail = new Order { FoodDescription = "Mee goreng", OrderQuantity = 1 };
            // Act 
            orderDetail.OrderQuantity = 2;
            // Assert
            Assert.Equal(2, orderDetail.OrderQuantity);
        }
    }
}
