using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RViP1
{
    class SMTP
    {
        public void SmtpList(List<Info> list, string email, string where, string text)
        {
            Info I = new Info();
            I.email = email;
            I.where = where;
            I.text = text;
            list.Add(I);
        }

        public void Smtp(bool block1, bool block2, List<Info> list1, List<Info> list2, List<Info> list3)
        {
            if (!block1)
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    SmtpList(list2, list1[i].email, list1[i].where, list1[i].text);
                    list1.Clear();
                }
            }
            else
            {
                if (!block2)
                {
                    for (int i = 0; i < list1.Count; i++)
                    {
                        SmtpList(list3, list1[i].email, list1[i].where, list1[i].text);
                        list1.Clear();
                    }
                }
            }
        }
    }
}
