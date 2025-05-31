import { ReactNode } from "react";

import { AppSidebar } from "@repo/ui/components/app-sidebar";
import { SiteHeader } from "@repo/ui/components/site-header";
import { SidebarProvider } from "@repo/ui/components/ui/sidebar/useSidebar";
import { SidebarInset } from "@repo/ui/components/ui/sidebar/sidebar-inset";

export const SidebarMainLayout = ({ children }: { children: ReactNode }) => {
  return (
    <SidebarProvider>
      <AppSidebar variant="inset" />
      <SidebarInset>
        <SiteHeader />
        <div className="flex flex-1 flex-col">
          <div className="@container/main flex flex-1 flex-col gap-2">
            <div className="flex flex-col gap-4 py-4 md:gap-6 md:py-6">
              {children}
            </div>
          </div>
        </div>
      </SidebarInset>
    </SidebarProvider>
  );
};
