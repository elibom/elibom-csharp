using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Elibom
{
    public class ElibomClient : Resource
    {
        public ElibomClient(string user, string token)
            : base(user, token)
        {
        }

        public string sendMessage(string to, string txt)
        {
            Message message = new Message(this.User, this.Token);
            return message.send(to, txt);
        }

        public dynamic getDelivery(string id) 
        {
            Delivery deliveryController = new Delivery(this.User, this.Token);
            dynamic delivery = deliveryController.get(id);
            return delivery;
        }

        public string scheduleMessage(string to, string txt, string date)
        {
            Schedule scheduleController = new Schedule(this.User, this.Token);
            return scheduleController.schedule(to, txt, date);
        }

        public dynamic getScheduledMessage(string id)
        {
            Schedule scheduleController = new Schedule(this.User, this.Token);
            dynamic schedule = scheduleController.get(id);
            return schedule;
        }

        public dynamic getScheduledMessages()
        {
            Schedule scheduleController = new Schedule(this.User, this.Token);
            dynamic schedules = scheduleController.getAll();
            return schedules;
        }

        public void unscheduleMessage(string id)
        {
            Schedule scheduleController = new Schedule(this.User, this.Token);
            scheduleController.unschedule(id);
        }

        public dynamic getUser(string id)
        {
            User userController = new User(this.User, this.Token);
            dynamic user = userController.get(id);
            return user;

        }

        public dynamic getUsers()
        {
            User userController = new User(this.User, this.Token);
            dynamic users = userController.getAll();
            return users;
        }

        public dynamic getAccount()
        {
            Account accountController = new Account(this.User, this.Token);
            dynamic account = accountController.get();
            return account;
        }
     }
}
