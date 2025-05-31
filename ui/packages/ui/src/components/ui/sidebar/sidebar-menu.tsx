import { mergeClassValues } from "../../../functions/merge-class-values";

export function SidebarMenu({
  className,
  ...props
}: React.ComponentProps<"ul">) {
  return (
    <ul
      data-slot="sidebar-menu"
      data-sidebar="menu"
      className={mergeClassValues(
        "flex w-full min-w-0 flex-col gap-1",
        className,
      )}
      {...props}
    />
  );
}
