import { mergeClassValues } from "../../../functions/merge-class-values";

export function SidebarGroup({
  className,
  ...props
}: React.ComponentProps<"div">) {
  return (
    <div
      data-slot="sidebar-group"
      data-sidebar="group"
      className={mergeClassValues(
        "relative flex w-full min-w-0 flex-col p-2",
        className,
      )}
      {...props}
    />
  );
}
