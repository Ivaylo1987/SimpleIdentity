namespace SimpleIdentity.Parsers
{
    using SimpleIdentity.Models;
    using SimpleIdentity.Models.Contracts;
    using SimpleIdentity.Parsers.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    public class XElementUserParser : IParser<IUser>
    {
        private string fileName;
        public XElementUserParser(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<IUser> GetAll()
        {
            return this.ParseUsers();
        }

        public void Add(IUser user)
        {
            this.AddUserTofile(user);
        }

        private IEnumerable<IUser> ParseUsers()
        {
            var xmlUsers = this.LoadUsersFromFile(this.fileName);
            var users = this.CreateUsersFromXElements(xmlUsers);
            return users;
        }

        private IEnumerable<XElement> LoadUsersFromFile(string filename)
        {
            var document = XDocument.Load(this.fileName);
            return document.Descendants("User");
        }

        private IEnumerable<IUser> CreateUsersFromXElements(IEnumerable<XElement> xmlUsers)
        {
            var users = xmlUsers.Select(this.ConvertXElementToUser);
            return users;
        }

        private void AddUserTofile(IUser user)
        {
            var document = XDocument.Load(this.fileName);
            var xmlUser = this.ConvertUserToXElement(user);

            document.Root.AddFirst(xmlUser);
            document.Save(fileName);
        }

        private User ConvertXElementToUser(XElement element)
        {
            var user = new User();
            user.UserName = element.Attribute("UserName").Value;
            user.Password = element.Attribute("Password").Value;
            return user;
        }

        private XElement ConvertUserToXElement(IUser user)
        {
            var xmlUser = new XElement("User");
            xmlUser.SetAttributeValue("UserName", user.UserName);
            xmlUser.SetAttributeValue("Password", user.Password);
            return xmlUser;
        }
    }
}
