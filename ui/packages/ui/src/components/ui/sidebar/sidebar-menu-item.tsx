import { mergeClassValues } from "../../../functions/merge-class-values";

export function SidebarMenuItem({
  className,
  ...props
}: React.ComponentProps<"li">) {
  return (
    <li
      data-slot="sidebar-menu-item"
      data-sidebar="menu-item"
      className={mergeClassValues("group/menu-item relative", className)}
      {...props}
    />
  );
}
