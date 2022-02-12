using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCarStore.Data;
using WebApplicationCarStore.Data.Entities;

namespace WebApplicationCarStore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCallBacksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiCallBacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/ApiCallBacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CallBack>> PostCallBack(CallBack callBack)
        {
            _context.CallBack.Add(callBack);
            await _context.SaveChangesAsync();

            Helpers.Notification.Telegram.SendMessage($"Заявка от {callBack.Name}\nНомер телефона: {callBack.Phone}\n(30 секунд на ответ!)");

            //await Helpers.Notification.Mail.SendEmailAsync();
            await Helpers.Notification.Mail
                .SendEmailAsync(
                "daniali230410@gmail.com", "text",
                "<div style='font-family: Arial; '>"
                    +"<hr style = 'height: 40px; background-color: orange;' >"
                    +"<h1 style = 'font-size: 62px; text-align: center;' > Toyota </ h1 >"
                    +"<div>"
                    +"<p style = 'font-size: 24px; margin-left: 25px; margin-top: 8rem;' >"
                      +$"Имя отправителя: {callBack.Name}<br>"
                      +$"Телефон отправилетя: {callBack.Phone}<br>"
                      +$"Email отправителя: {callBack.Email}<br>"
                      +"Связаться за 1-ту минуту"
                    +"</p>"
                    +"<div style = 'color: white; margin-top: 8rem; font-size: 22px; text-align: center; background-color: rgb(0, 0, 0, 0.5); padding-top: 10px;padding-bottom: 10px;' >"
                    +"<h2> ИНФОРМАЦТИЯ НЕ ЯВЛЯЕТЬСЯ СПАМОМ </h2>"
                    +"<p style = 'font-size: 14px; text-align: center;' > ВАМИ БЫЛО НАДАНО РАЗРЕШНИЕ ОТПРАВКИ ДЛЯ СВЯЗИ</ p >"
                    +"</div>"
                    +"</div>"
                    +"<hr style = 'height: 40px; background-color: orange;' >"
                    +"</div>"
                );
            await Helpers.Notification.Mail.SendEmailAsync(callBack.Email);
            return CreatedAtAction("GetCallBack", new { id = callBack.Id }, callBack);
        }
 
        private bool CallBackExists(Guid id)
        {
            return _context.CallBack.Any(e => e.Id == id);
        }
    }
}
