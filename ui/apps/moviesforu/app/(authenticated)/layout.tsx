import { SidebarMainLayout } from "@repo/layouts/sidebarMainLayout";

export const metadata = {
  title: "Moviesforu",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return <SidebarMainLayout>{children}</SidebarMainLayout>;
}
