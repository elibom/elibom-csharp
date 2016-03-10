using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elibom.APIClient.Resources;

namespace Elibom.APIClient
{
    public class ElibomClient
    {
        protected RestClient ApiClient;

        public ElibomClient(string user, string password)
        {
            this.ApiClient = new RestClient(user, password);
        }

        public string sendMessage(string to, string txt)
        {
            Message message = new Message(this.ApiClient);
            return message.send(to, txt);
        }

        public string sendMessage(string to, string txt, string campaign)
        {
            Message message = new Message(this.ApiClient);
            return message.send(to, txt, campaign);
        }

        public dynamic getDelivery(string id) 
        {
            Delivery deliveryController = new Delivery(this.ApiClient);
            dynamic delivery = deliveryController.get(id);
            return delivery;
        }

        public string scheduleMessage(string to, string txt, string date)
        {
            Schedule scheduleController = new Schedule(this.ApiClient);
            return scheduleController.schedule(to, txt, date);
        }

        public string scheduleMessage(string to, string txt, string date, string campaign)
        {
            Schedule scheduleController = new Schedule(this.ApiClient);
            return scheduleController.schedule(to, txt, date, campaign);
        }

        public dynamic getScheduledMessage(string id)
        {
            Schedule scheduleController = new Schedule(this.ApiClient);
            dynamic schedule = scheduleController.get(id);
            return schedule;
        }

        public dynamic getScheduledMessages()
        {
            Schedule scheduleController = new Schedule(this.ApiClient);
            dynamic schedules = scheduleController.getAll();
            return schedules;
        }

        public void unscheduleMessage(string id)
        {
            Schedule scheduleController = new Schedule(this.ApiClient);
            scheduleController.unschedule(id);
        }

        public dynamic getUser(string id)
        {
            User userController = new User(this.ApiClient);
            dynamic user = userController.get(id);
            return user;

        }

        public dynamic getUsers()
        {
            User userController = new User(this.ApiClient);
            dynamic users = userController.getAll();
            return users;
        }

        public dynamic getAccount()
        {
            Account accountController = new Account(this.ApiClient);
            dynamic account = accountController.get();
            return account;
        }
     }
}
