import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../../../shared/service/logger.service';
import { RouterFacade } from '../../../shared/facade/router.facade';

@Component({
	selector: 'app-signup-step-first',
	templateUrl: './signup-step-first.component.html',
	styleUrls: ['./signup-step-first.component.scss'],
})
export class SignupStepFirstComponent implements OnInit {
	public constructor(private _logger: LoggerService, private _router: RouterFacade) {}

	public ngOnInit(): void {
		this._logger.info('SignupStepFirstComponent ngOnInit');
	}

	public onClick($event: MouseEvent) {
		console.log($event);
		this._router.stepSecond();
	}
}
