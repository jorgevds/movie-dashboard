import { mergeClassValues } from "../../../functions/merge-class-values";

export function SidebarFooter({
  className,
  ...props
}: React.ComponentProps<"div">) {
  return (
    <div
      data-slot="sidebar-footer"
      data-sidebar="footer"
      className={mergeClassValues("flex flex-col gap-2 p-2", className)}
      {...props}
    />
  );
}
