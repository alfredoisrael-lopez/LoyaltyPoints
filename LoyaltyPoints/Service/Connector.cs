using System;
using LoyaltyPoints.Model;
using Pomelo.Data.MySql;
namespace LoyaltyPoints.Service
{
    public class Connector
    {
        public String connectionString;
        public Connector()
        {
            connectionString = Environment.GetEnvironmentVariable("CONN_STRING");
        }

        public CustomerLoyaltyPoints GetPoints(String customerNumber)
        {

            CustomerLoyaltyPoints customer = new CustomerLoyaltyPoints();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT CLIENT_NUMBER, BALANCE_POINTS FROM LOYALTY_POINTS_CUSTOMERS WHERE CLIENT_NUMBER = " + customerNumber;
                    command.CommandType = System.Data.CommandType.Text;

                    command.Connection = connection;
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new CustomerLoyaltyPoints{ 
                                CustomerNumber = reader.GetString("CLIENT_NUMBER"), 
                                CustomerBalancePoints = reader.GetInt32("BALANCE_POINTS")
                            };
                        }
                    }

                    connection.Close();
                }
            }

            return customer;
        }

        public void redeemPoint(String customerNumber, int pointsToRedeem)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE LOYALTY_POINTS_CUSTOMERS SET BALANCE_POINTS = BALANCE_POINTS-" + pointsToRedeem + " WHERE CLIENT_NUMBER = " + customerNumber + "";
                    command.CommandType = System.Data.CommandType.Text;

                    command.Connection = connection;
                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }
        }
    }
}

