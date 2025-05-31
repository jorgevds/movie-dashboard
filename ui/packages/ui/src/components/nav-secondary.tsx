"use client";

import * as React from "react";
import { type Icon } from "@tabler/icons-react";
import { SidebarGroup } from "./ui/sidebar/sidebar-group";
import { SidebarGroupContent } from "./ui/sidebar/sidebar-group-content";
import { SidebarMenu } from "./ui/sidebar/sidebar-menu";
import { SidebarMenuItem } from "./ui/sidebar/sidebar-menu-item";
import { SidebarMenuButton } from "./ui/sidebar/sidebar-menu-button";

export function NavSecondary({
  items,
  ...props
}: {
  items: {
    title: string;
    url: string;
    icon: Icon;
  }[];
} & React.ComponentPropsWithoutRef<typeof SidebarGroup>) {
  return (
    <SidebarGroup {...props}>
      <SidebarGroupContent>
        <SidebarMenu>
          {items.map((item) => (
            <SidebarMenuItem key={item.title}>
              <SidebarMenuButton asChild>
                <a href={item.url}>
                  <item.icon />
                  <span>{item.title}</span>
                </a>
              </SidebarMenuButton>
            </SidebarMenuItem>
          ))}
        </SidebarMenu>
      </SidebarGroupContent>
    </SidebarGroup>
  );
}
