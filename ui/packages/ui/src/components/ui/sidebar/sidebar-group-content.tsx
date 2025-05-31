import { mergeClassValues } from "../../../functions/merge-class-values";

export function SidebarGroupContent({
  className,
  ...props
}: React.ComponentProps<"div">) {
  return (
    <div
      data-slot="sidebar-group-content"
      data-sidebar="group-content"
      className={mergeClassValues("w-full text-sm", className)}
      {...props}
    />
  );
}
