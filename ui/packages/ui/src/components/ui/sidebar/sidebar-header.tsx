import { mergeClassValues } from "../../../functions/merge-class-values";

export function SidebarHeader({
  className,
  ...props
}: React.ComponentProps<"div">) {
  return (
    <div
      data-slot="sidebar-header"
      data-sidebar="header"
      className={mergeClassValues("flex flex-col gap-2 p-2", className)}
      {...props}
    />
  );
}
