import { Separator } from "@repo/ui/components/ui/separator";
import { mergeClassValues } from "../../../functions/merge-class-values";

export function SidebarSeparator({
  className,
  ...props
}: React.ComponentProps<typeof Separator>) {
  return (
    <Separator
      data-slot="sidebar-separator"
      data-sidebar="separator"
      className={mergeClassValues("bg-sidebar-border mx-2 w-auto", className)}
      {...props}
    />
  );
}
