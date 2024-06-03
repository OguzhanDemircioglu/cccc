﻿export class MenuModel {
  name: string = "";
  icon: string = "";
  url: string = "";
  isTitle: boolean = false;
  subMenus: MenuModel[] = [];
}

export const Menus: MenuModel[] = [
  {
    name: "Anasayfa",
    icon: "fas fa-solid fa-home",
    url: "/",
    isTitle: false,
    subMenus: []
  },
  {
    name: "Ana Group",
    icon: "far fa-solid fa-trowel-bricks",
    url: "/",
    isTitle: false,
    subMenus: [
      {
        name: "Müşteriler",
        icon: "far fa-solid fa-users",
        url: "/customers",
        isTitle: false,
        subMenus: []
      },
      {
        name: "Depot",
        icon: "far fa-solid fa-depots",
        url: "/Depots",
        isTitle: false,
        subMenus: []
      },
    ]
  }
]

