import { PanelComponent } from "./panel/panel.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";

const productsRoutes: Routes = [
  {
    path: "products",
    component: PanelComponent
  }
];

@NgModule({
  imports: [CommonModule, RouterModule.forChild(productsRoutes)],
  declarations: [],
  exports: [RouterModule]
})
export class ProductsRoutingModule {}
