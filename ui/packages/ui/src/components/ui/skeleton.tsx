import { mergeClassValues } from "../../functions/merge-class-values";

function Skeleton({ className, ...props }: React.ComponentProps<"div">) {
  return (
    <div
      data-slot="skeleton"
      className={mergeClassValues(
        "bg-accent animate-pulse rounded-md",
        className,
      )}
      {...props}
    />
  );
}

export { Skeleton };
