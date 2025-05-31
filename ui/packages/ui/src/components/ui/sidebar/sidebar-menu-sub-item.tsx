import { mergeClassValues } from "../../../functions/merge-class-values";

export const SidebarMenuSubItem = ({
  className,
  ...props
}: React.ComponentProps<"li">) => (
  <li
    data-slot="sidebar-menu-sub-item"
    data-sidebar="menu-sub-item"
    className={mergeClassValues("group/menu-sub-item relative", className)}
    {...props}
  />
);
