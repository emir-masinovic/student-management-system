import { Component, inject } from '@angular/core';
import { ServiceService } from '../service.service';
import { MaterialModule } from '../material/material.module';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-mainpage',
  imports: [MaterialModule, DragDropModule],
  templateUrl: './mainpage.component.html',
  styleUrl: './mainpage.component.css',
})
export class MainpageComponent {
  private _snackbar = inject(MatSnackBar);

  lstData: any = [];

  constructor(private service: ServiceService) {}

  // prettier-ignore
  ngOnInit() { this.getAllPokemonData(); }

  getAllPokemonData() {
    this.service.getAllPokemonData().subscribe({
      next: (res: any) => {
        console.log('pokemonObj', res);
        this._snackbar.open('We got pokemon', 'Close me');
        this.lstData = res;
      },
      // prettier-ignore
      error: (error: any) => { console.log(error); },
    });
  }

  drop(event: CdkDragDrop<{ name: string }[]>) {
    moveItemInArray(this.lstData, event.previousIndex, event.currentIndex);
  }
}
