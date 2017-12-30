import { ProductsRoutingModule } from "./products-routing.module";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProductListComponent } from "./product-list/product-list.component";
import { PanelComponent } from "./panel/panel.component";

@NgModule({
  imports: [CommonModule, ProductsRoutingModule],
  declarations: [ProductListComponent, PanelComponent]
})
export class ProductsModule {}
