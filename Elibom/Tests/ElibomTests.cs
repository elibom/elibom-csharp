using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Elibom.APIClient;
using System.Collections.Generic;

namespace ElibomTesting
{
    [TestClass]
    public class ElibomTests
    {
        [TestMethod]
        public void shouldSendMessage()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/messages/"},
                {"method", "POST"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                },
                {"body", "{\"destinations\":\"3001111111\",\"text\":\"testing\"}"}
            };
            String response = "{\"deliveryToken\":\"token123\"}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            string deliveryId = elibom.sendMessage("3001111111", "testing");
            Assert.IsTrue("token123".Equals(deliveryId));
        }

        [TestMethod]
        public void shouldSendMessageWithCampaign()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/messages/"},
                {"method", "POST"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                },
                {"body", "{\"destinations\":\"3001111111\",\"text\":\"testing\",\"campaign\":\"campaign-testing\"}"}
            };
            String response = "{\"deliveryToken\":\"token123\"}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            string deliveryId = elibom.sendMessage("3001111111", "testing", "campaign-testing");
            Assert.IsTrue("token123".Equals(deliveryId));
        }

        [TestMethod]
        public void shouldShowDelivery()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/messages/12345"},
                {"method", "GET"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                }
            };
            String response = "{\"data\":{\"token\":\"12345\"}}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            var delivery = elibom.getDelivery("12345");
            Assert.IsTrue("12345".Equals(delivery["data"]["token"]));
        }

        [TestMethod]
        public void shouldScheduleMessage()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/messages/"},
                {"method", "POST"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                },
                {"body", "{\"destinations\":\"3001111111\",\"text\":\"testing\",\"scheduledDate\":\"03/02/2089\"}"}
            };
            String response = "{\"scheduleId\":\"123\"}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            string deliveryId = elibom.scheduleMessage("3001111111", "testing", "03/02/2089");
            Assert.IsTrue("123".Equals(deliveryId));
        }

        [TestMethod]
        public void shouldScheduleMessageWithCampaign()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/messages/"},
                {"method", "POST"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                },
                {"body", "{\"destinations\":\"3001111111\",\"text\":\"testing\",\"scheduledDate\":\"03/02/2089\",\"campaign\":\"campaign-testing\"}"}
            };
            String response = "{\"scheduleId\":\"123\"}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            string deliveryId = elibom.scheduleMessage("3001111111", "testing", "03/02/2089", "campaign-testing");
            Assert.IsTrue("123".Equals(deliveryId));
        }

        [TestMethod]
        public void shouldShowScheduledMessage()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/schedules/777"},
                {"method", "GET"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                }
            };
            String response = "{\"data\":{\"id\":\"777\"}}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            var schedule = elibom.getScheduledMessage("777");
            Assert.IsTrue("777".Equals(schedule["data"]["id"]));
        }

        [TestMethod]
        public void shouldShowScheduledMessages()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/schedules/scheduled"},
                {"method", "GET"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                }
            };
            String response = "[{\"id\":\"777\"}]";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            var schedules = elibom.getScheduledMessages();
            Assert.IsTrue("777".Equals(schedules[0]["id"]));
        }

        [TestMethod]
        public void shouldCancelSchedule()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/schedules/777"},
                {"method", "DELETE"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                }
            };
            String response = "{}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            elibom.unscheduleMessage("777");
        }

        [TestMethod]
        public void shouldListUsers()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/users/"},
                {"method", "GET"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                }
            };
            String response = "[{\"data\":{\"name\":\"carlos\"}}]";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            var users = elibom.getUsers();
            Assert.IsTrue("carlos".Equals(users[0]["data"]["name"]));
        }

        [TestMethod]
        public void shouldShowUser()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/users/777"},
                {"method", "GET"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                }
            };
            String response = "{\"data\":{\"name\":\"carlos\"}}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            var user = elibom.getUser("777");
            Assert.IsTrue("carlos".Equals(user["data"]["name"]));
        }

        [TestMethod]
        public void shouldShowAccount()
        {
            ElibomClient elibom = new ElibomClientMock("user@elibom.com", "password123");

            Dictionary<string, Object> expectedRequest = new Dictionary<string, Object>() {
                {"url", "https://www.elibom.com/account"},
                {"method", "GET"},
                {"headers", new Dictionary<string, string>() {
                            { "Authorization", "Basic dXNlckBlbGlib20uY29tOnBhc3N3b3JkMTIz"},
                            { "X-API-Source", "csharp-1.0.6"}
                     }
                }
            };
            String response = "{\"data\":{\"name\":\"account-name\"}}";

            ((ElibomClientMock)elibom).stubRequest(expectedRequest, response);

            var account = elibom.getAccount();
            Assert.IsTrue("account-name".Equals(account["data"]["name"]));
        }
    }
}
