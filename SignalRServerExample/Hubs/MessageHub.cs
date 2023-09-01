using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {

        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        //{ 

        //}
            public async Task SendMessageAsync(string message,string groupName,IEnumerable<string> connectionIds)
        {
            #region All 
            // Servera bağlı olan tüm clientlarla iletişim kurar

            //  await Clients.All.SendAsync("receiveMessage", message); // Client türleri : All- Caller-Other
            #endregion
            #region Caller
            // Servera bildirim gönderen clientlarla iletişim kurar

            // await Clients.Caller.SendAsync("receiveMessage", message);

            #endregion

            #region Other

            // Sadece server'a bildirim gönderen client dışında Server'a bağlı olan tüm client'lara mesaj gönderir.

            //  await Clients.Others.SendAsync("receiveMessage", message);

            #endregion

            #region AllExcept

            //Belirtilen  clientlar hariç server'a bağlı olan tüm clientlara bildiride bulunur. 

            //  await   Clients.AllExcept(connectionIds).SendAsync("receiveMessage",message);

            #endregion

            #region Client

            // Mevcuttaki clientlardan herhangi birine mesaj gödermek istersek
            // await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);

            #endregion

            #region Clients

            //Clientlar arasından sadece belirtilenlere bildiride bulunur. 

            #endregion

            #region Group

            //Belirtilen gruptaki tüm clientlara bildiride bulunur.
            //Önce gruplar oluşturulmalı ve ardından clientlar gruplara subscribe olmalı.

            //Clientın sadece dahil olduğu gruba mesaj atmasını sağlayabilmek için bizim programatik olarak o clientın o gruba dahil mi değil mi kontrolunu yapmamız gerekiyor.(Kendimiz)

            //  await  Clients.Group(groupName).SendAsync("receiveMessage", message);



            #endregion

            #region GroupExcept

            //Belirtilen gruptaki,belirtilen clientlar dışındaki tüm clientlara mesaj iletmemizi sağlayan bir fonksiyondur.

            //  await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);

            #endregion

            #region Groups

            //Birden çok gruptaki clientlara bildiride bulunmamızı sağlayan fonksiyondur.



            #endregion
              
            #region OthersInGroup

            //Bildiride bulunan client haricinde gruptaki tüm clientlara bildiride bulunan fonksiyonumuzdur.



            #endregion
        }



        public override async Task OnConnectedAsync() //Huba bir client bağlandığı zaman tetiklenen fonksiyon 
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
            
        }

        public async Task addGroup(string connectionId,string groupName)
        {
          await  Groups.AddToGroupAsync(connectionId, groupName);
        }

    }
}
