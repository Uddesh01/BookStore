﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IWishListBL
    {
      public bool  AddToWishList(long userId, long bookId);
      public bool  RemoveFromWishList(long userId, long bookId);
    }
}
