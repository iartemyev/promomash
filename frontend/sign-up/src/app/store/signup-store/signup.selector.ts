import { IRootState } from '../root-state';
import { ISignUpState } from './signup.state';
import { createSelector } from '@ngrx/store';

const signUpState = (state: IRootState) => state.signUpState;

export const login = createSelector(signUpState, (state: ISignUpState) => state.login);
export const password = createSelector(signUpState, (state: ISignUpState) => state.password);
export const isAgree = createSelector(signUpState, (state: ISignUpState) => state.isAgree);

export const countryListLoading = createSelector(
	signUpState,
	(state: ISignUpState) => state.countryListLoading,
);

export const countryList = createSelector(signUpState, (state: ISignUpState) => state.countryList);

export const provinceListLoading = createSelector(
	signUpState,
	(state: ISignUpState) => state.provinceListLoading,
);

export const provinceList = createSelector(
	signUpState,
	(state: ISignUpState) => state.provinceList,
);

export const signUpLoading = createSelector(
	signUpState,
	(state: ISignUpState) => state.signUpLoading,
);
