import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { RouterModule, Routes } from "@angular/router";

import { PanelComponent } from "./panel/panel.component";

const routes: Routes = [
  {
    path: "animals",
    component: PanelComponent
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(routes)],
  declarations: [PanelComponent],
  exports: [RouterModule]
})
export class AnimalRoutingModule {}
