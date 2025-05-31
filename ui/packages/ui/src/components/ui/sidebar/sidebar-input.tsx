"use client";

import { mergeClassValues } from "../../../functions/merge-class-values";
import { Input } from "../input";

export function SidebarInput({
  className,
  ...props
}: React.ComponentProps<typeof Input>) {
  return (
    <Input
      data-slot="sidebar-input"
      data-sidebar="input"
      className={mergeClassValues(
        "bg-background h-8 w-full shadow-none",
        className,
      )}
      {...props}
    />
  );
}
