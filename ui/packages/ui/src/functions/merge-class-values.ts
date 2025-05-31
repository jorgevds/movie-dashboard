import { clsx, type ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";

/** Combined Tailwind Merge & conditional class-naming.
 * - twMerge: avoids duplicate styles and conflicts through re-declaring rulesets
 *   - clsx: add classes based on conditions (e.g. isMobile && 'is-mobile')
 * */
export function mergeClassValues(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}
